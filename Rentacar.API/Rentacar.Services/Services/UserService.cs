using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Entities;
using Rentacar.Entities.Enums;
using Rentacar.Resources.Exceptions;
using Rentacar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<BaseUserDto>> FilterUsers(FilterUsersDto filterUsersDto)
        {
            if(filterUsersDto == null)
            {
                throw new ArgumentNullException();
            }

            List<User> filteredUsers = await _userRepository.FilterUsers(filterUsersDto.UserId, filterUsersDto.FirstName, filterUsersDto.LastName, filterUsersDto.Username);

            return _mapper.Map<List<BaseUserDto>>(filteredUsers);
        }

        public async Task<UserDto> LoginUser(LoginRequestDto loginRequestDto)
        {
            User userEf = await _userRepository.GetUserForLogin(loginRequestDto.Username, loginRequestDto.Password);

            if (userEf != null)
            {
                UserDto mappedUser = _mapper.Map<UserDto>(userEf);
                mappedUser.Token = IssueToken(mappedUser.Username);
                await SaveIssuedToken(mappedUser.Token, userEf.UserId);
                await SaveLoginAttempt(mappedUser.Username, LoginStatus.Success, mappedUser.UserId);
                return mappedUser;
            }

            await SaveLoginAttempt(loginRequestDto.Username, LoginStatus.Failed, null);
            throw new UserNotFoundException();
        }

        private async Task SaveIssuedToken(string token, int userId)
        {
            IssuedToken issuedToken = new IssuedToken()
            {
                IssuedOn = DateTime.Now,
                TokenValue = token,
                ValidFor = 3600,
                UserId = userId
            };
            await _userRepository.SaveIssuedToken(issuedToken);
        }

        private async Task SaveLoginAttempt(string username, LoginStatus loginStatus, int? userId)
        {
            LoginAttempt attempt = new LoginAttempt()
            {
                AttemptedOn = DateTime.Now,
                Username = username,
                UserId = userId,
                Status = (int)loginStatus
            };
            await _userRepository.SaveLoginAttempt(attempt);
        }

        public async Task<UserDto> RegisterUser(UserDto userDto)
        {
            AssertionHelper.AssertString(userDto.Username);
            AssertionHelper.AssertString(userDto.FirstName);
            AssertionHelper.AssertString(userDto.LastName);
            AssertionHelper.AssertString(userDto.Password);

            User userEf = _mapper.Map<User>(userDto);

            User registeredUser = await _userRepository.RegisterUser(userEf);

            UserDto registeredMappedUser = _mapper.Map<UserDto>(registeredUser);
            registeredMappedUser.Token = IssueToken(registeredMappedUser.Username);
            await SaveIssuedToken(registeredMappedUser.Token, userEf.UserId);
            await SaveLoginAttempt(registeredMappedUser.Username, LoginStatus.Success, registeredMappedUser.UserId);

            return registeredMappedUser;
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            var updatedUser = await _userRepository.UpdateUser(_mapper.Map<User>(userDto));

            var mappedUpdatedUser = _mapper.Map<UserDto>(updatedUser);
            mappedUpdatedUser.Token = IssueToken(mappedUpdatedUser.Username);
            await SaveIssuedToken(mappedUpdatedUser.Token, updatedUser.UserId);

            return mappedUpdatedUser;
        }

        private string IssueToken(string username)
        {
            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes("SuperSercretKey for the encryption");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, username)
              }),
                Expires = DateTime.UtcNow.AddMinutes(3600),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
