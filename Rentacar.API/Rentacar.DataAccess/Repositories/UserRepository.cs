using Microsoft.EntityFrameworkCore;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Entities;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RentacarContext _context;
        public UserRepository(RentacarContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserForLogin(string userEmail, string password)
        {
            // Validate
            AssertionHelper.AssertString(userEmail);
            AssertionHelper.AssertString(password);

            // Get user if exists
            return await _context.Users
                                 .Include(x => x.Role)
                                 .FirstOrDefaultAsync(user => user.Email == userEmail && user.Password == password);
        }

        public async Task<User> RegisterUser(User user)
        {
            // Validate user
            AssertionHelper.AssertObject(user);

            // Add user do database
            User addedUser = _context.Users.Add(user).Entity;
            await _context.SaveChangesAsync();

            // Return added user
            return addedUser;
        }
    }
}
