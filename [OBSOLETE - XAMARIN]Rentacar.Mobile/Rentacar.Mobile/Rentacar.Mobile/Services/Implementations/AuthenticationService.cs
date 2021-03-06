using Rentacar.Dto;
using Rentacar.Dto.Request;
using Rentacar.Mobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private static string _baseUrl = HttpHelper.BaseUrl + "api/Users";
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public async Task<UserDto> Register(UserDto userDto)
        {
            UserDto registeredUser;
            try
            {
                registeredUser = await HttpHelper.PostAsync<UserDto, UserDto>(_baseUrl + "/register", userDto);
                UserId = registeredUser?.UserId ?? 0;
                User = registeredUser;
            }
            catch
            {
                return null;
            }
            return registeredUser;
        }

        public async Task<UserDto> SignIn(string username, string password)
        {
            UserDto loggedUser;
            try
            {
                loggedUser = await HttpHelper.PostAsync<UserDto, LoginRequestDto>(_baseUrl + "/login", new LoginRequestDto { Email = username, Password = password });
                UserId = loggedUser?.UserId ?? 0;
                User = loggedUser;
            }
            catch
            {
                return null;
            }

            return loggedUser;
        }
    }
}
