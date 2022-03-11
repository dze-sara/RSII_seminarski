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

        public async Task<UserDto> Register(UserDto userDto)
        {
            UserDto registeredUser = await HttpHelper.PostAsync<UserDto, UserDto>(_baseUrl, userDto);
            return registeredUser;
        }

        public async Task<UserDto> SignIn(string username, string password)
        {
            var x = await HttpHelper.GetAsync<List<BaseBookingDto>>(HttpHelper.BaseUrl + "api/Bookings/active");

            UserDto loggedUser = await HttpHelper.PostAsync<UserDto, LoginRequestDto>(_baseUrl + "/login", new LoginRequestDto { Email = username, Password = password });
            return loggedUser;
        }
    }
}
