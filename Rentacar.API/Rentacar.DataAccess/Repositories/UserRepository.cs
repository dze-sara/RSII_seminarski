using Microsoft.EntityFrameworkCore;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<User>> FilterUsers(int? userId, string firstName, string lastName, string email)
        {
            // Query
            var usersQuery = _context.Users
                                     .Include(x => x.Role)
                                     .AsQueryable();

            if(userId > 0)
            {
                usersQuery = usersQuery.Where(x => x.UserId == userId);
            }

            if(!string.IsNullOrWhiteSpace(firstName))
            {
                usersQuery = usersQuery.Where(x => x.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                usersQuery = usersQuery.Where(x => x.LastName.Contains(lastName));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                usersQuery = usersQuery.Where(x => x.Email.Contains(email));
            }

            // Execute
            return await usersQuery.ToListAsync();
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

        public async Task<User> UpdateUser(User user)
        {
            User updatingUser = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
            updatingUser.FirstName = user.FirstName;
            updatingUser.LastName = user.LastName;
            updatingUser.Email = user.Email;
            updatingUser.Password = user.Password;
            await _context.SaveChangesAsync();
            return updatingUser;
        }
    }
}
