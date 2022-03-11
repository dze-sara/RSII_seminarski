using AutoMapper;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Entities;
using Rentacar.Resources.Exceptions;
using Rentacar.Services.Interfaces;
using System;
using System.Collections.Generic;
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
                return _mapper.Map<UserDto>(userEf);
            }

            throw new UserNotFoundException();
        }

        public async Task<UserDto> RegisterUser(UserDto userDto)
        {
            User userEf = _mapper.Map<User>(userDto);

            User registeredUser = await _userRepository.RegisterUser(userEf);

            return _mapper.Map<UserDto>(registeredUser);
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            return _mapper.Map<UserDto>(await _userRepository.UpdateUser(_mapper.Map<User>(userDto)));
        }
    }
}
