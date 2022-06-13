using Rentacar.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services.Interfaces
{
    public interface IAuthenticationService
    {
        int UserId { get; set; }
        UserDto User { get; set; }
        Task<UserDto> Register(UserDto userDto);
        Task<UserDto> SignIn(string username, string password);
    }
}
