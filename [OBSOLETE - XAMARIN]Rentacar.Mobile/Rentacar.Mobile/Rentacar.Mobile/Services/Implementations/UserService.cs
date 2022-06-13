using Rentacar.Dto;
using Rentacar.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services
{
    public class UserService : IUserService
    {
        private static string _baseUrl = HttpHelper.BaseUrl + "api/Users";

        public async Task<UserDto> EditUserInfo(UserDto userDto)
        {
            return await HttpHelper.PostAsync<UserDto, UserDto>(_baseUrl + "/update", userDto);
        }
    }
}
