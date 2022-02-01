using AutoMapper;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Entities;
using Rentacar.Resources.Exceptions;
using Rentacar.Services.Interfaces;
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
    }
}
