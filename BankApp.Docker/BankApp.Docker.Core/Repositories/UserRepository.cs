using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Data;
using BankApp.Docker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Docker.Core
{
    public class UserRepository : IUserRepository
    {
        //privately injected fields
        private readonly IAccountRepository _accountRepository;
        private readonly AppDbContext _context;


        public UserRepository(AppDbContext context, IAccountRepository accountRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Command to add user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            int res = _context.SaveChanges();

            return res > 0;
        }

        /// <summary>
        /// Get a user by their E-mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUserByEmail(string email)
        {
            var user = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            if(user != null)
            {
                var accounts = _accountRepository.GetUserAccounts(user.UserId);
                user.UserAccounts = accounts;
            }
            return user;
        }
        /// <summary>
        /// Get all users in the database
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            // get the list of all users in a datatable
            var listUsers = _context.Users.Include(a => a.UserAccounts).ToList();

            return listUsers;
        }
    }
}
