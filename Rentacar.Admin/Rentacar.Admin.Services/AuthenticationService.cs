using Rentacar.Dto;
using Rentacar.Dto.Request;
using System.Threading.Tasks;

namespace Rentacar.Admin.Services
{
    public class AuthenticationService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"] + "api/users";

        public static async Task<bool> Login(string username, string password)
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto()
            {
                Username = username,
                Password = password
            };

            try
            {
                UserDto loggedInUser = await HttpHelper.PostAsync<UserDto, LoginRequestDto>(_baseUrl + "/login", loginRequestDto);
                HttpHelper.SetAuthenticationToken(loggedInUser?.Token);
                return loggedInUser?.Role?.RoleName == "Administrator";
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
