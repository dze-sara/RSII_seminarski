﻿using Rentacar.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserForLogin(string userEmail, string password);
        Task<User> RegisterUser(User user);
        Task<User> UpdateUser(User user);
        Task<List<User>> FilterUsers(int? userId, string firstName, string lastName, string email);
        Task<bool> SaveIssuedToken(IssuedToken issuedToken);
        Task<bool> SaveLoginAttempt(LoginAttempt loginAttempt);
    }
}
