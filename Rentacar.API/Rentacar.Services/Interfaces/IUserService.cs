using Rentacar.Dto;
using Rentacar.Dto.Request;
using System.Threading.Tasks;

namespace Rentacar.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(UserDto userDto);
        Task<UserDto> LoginUser(LoginRequestDto loginRequestDto);
    }
}
