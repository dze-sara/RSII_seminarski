using Rentacar.Dto;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> EditUserInfo(UserDto userDto);
    }
}
