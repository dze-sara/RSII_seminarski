using Newtonsoft.Json;
using Rentacar.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rentacar.Admin.Services
{
    public static class UserService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"] + "api/users";
        private static HttpClient _httpClient = new HttpClient();

        public static async Task<List<BaseUserDto>> FilterUsers(string userId, string firstName, string lastName, string email)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["userId"] = userId;
            parameters["firstName"] = firstName;
            parameters["lastName"] = lastName;
            parameters["email"] = email;

            List<BaseUserDto> listOfUsers = await HttpHelper.GetAsync<List<BaseUserDto>>(_baseUrl + "/filter", parameters);

            return listOfUsers;
        }

        public static async Task DeleteUser(string userId)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{userId}");
        }
    }
}
