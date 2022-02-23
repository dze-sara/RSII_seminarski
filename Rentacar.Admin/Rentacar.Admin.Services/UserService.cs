using Newtonsoft.Json;
using Rentacar.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rentacar.Admin.Services
{
    public static class UserService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"] + "/api/users";

        private static HttpClient _httpClient = new HttpClient();


        public static async Task<List<UserDto>> FilterUsers(string userId, string firstName, string lastName, string email)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["userId"] = userId;
            parameters["firstName"] = firstName;
            parameters["lastName"] = lastName;
            parameters["email"] = email;

            var filterUsersUrl = HttpHelper.BuildQueryParams(_baseUrl + "/filter", parameters);

            HttpResponseMessage response = await _httpClient.GetAsync(filterUsersUrl);
            var jsonObject = await response.Content.ReadAsStringAsync();
            var listOfUsers = JsonConvert.DeserializeObject<List<UserDto>>(jsonObject);

            return listOfUsers;
        }

        public static async Task DeleteUser(string userId)
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{userId}");
        }
    }
}
