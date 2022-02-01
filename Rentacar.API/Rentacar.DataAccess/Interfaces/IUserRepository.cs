using Rentacar.Entities;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserForLogin(string userEmail, string password);
        Task<User> RegisterUser(User user);

    }
}
