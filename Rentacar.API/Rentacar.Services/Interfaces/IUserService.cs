using Rentacar.Dto;
using Rentacar.Dto.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(UserDto userDto);
        Task<UserDto> LoginUser(LoginRequestDto loginRequestDto);
        Task<List<BaseUserDto>> FilterUsers(FilterUsersDto filterUsersDto);
        Task<UserDto> UpdateUser(UserDto userDto);
    }
}
