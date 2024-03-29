﻿using SULS.Data;
using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public class UserService : IUserService
    {
        private readonly SULSContext context;

        public UserService(SULSContext examDbContext)
        {
            this.context = examDbContext;
        }

        public User CreateUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User userFromDb = this.context.Users
                 .SingleOrDefault(user => (user.Username == username || user.Email == username)
                                                                    && user.Password == password);

            return userFromDb;
        }
    }
}
