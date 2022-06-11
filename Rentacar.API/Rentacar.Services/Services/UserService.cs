using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Entities;
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

            List<User> filteredUsers = await _userRepository.FilterUsers(filterUsersDto.UserId, filterUsersDto.FirstName, filterUsersDto.LastName, filterUsersDto.Email);

            return _mapper.Map<List<BaseUserDto>>(filteredUsers);
        }

        public async Task<UserDto> LoginUser(LoginRequestDto loginRequestDto)
        {
            User userEf = await _userRepository.GetUserForLogin(loginRequestDto.Email, loginRequestDto.Password);

            if (userEf != null)
            {
                UserDto mappedUser = _mapper.Map<UserDto>(userEf);
                mappedUser.Token = IssueToken(mappedUser.Email);
                return mappedUser;
            }

            throw new UserNotFoundException();
        }

        public async Task<UserDto> RegisterUser(UserDto userDto)
        {
            User userEf = _mapper.Map<User>(userDto);

            User registeredUser = await _userRepository.RegisterUser(userEf);

            UserDto registeredMappedUser = _mapper.Map<UserDto>(registeredUser);
            registeredMappedUser.Token = IssueToken(registeredMappedUser.Email);

            return registeredMappedUser;
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            return _mapper.Map<UserDto>(await _userRepository.UpdateUser(_mapper.Map<User>(userDto)));
        }


        private string IssueToken(string email)
        {
            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes("SuperSercretKey for the encryption");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, email)
              }),
                Expires = DateTime.UtcNow.AddMinutes(3600),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
