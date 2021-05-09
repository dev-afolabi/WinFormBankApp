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
        private readonly ITransactionRepository _transactionRepository;
        private readonly AppDbContext _context;


        public UserRepository(AppDbContext context)
        {
            _context = context;
            _accountRepository = GlobalConfig.AccountRepository;
            _transactionRepository = GlobalConfig.TransactionRepository;
        }
        /// <summary>
        /// Command to add user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return false;
        }

        /// <summary>
        /// Get a user by their E-mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUserByEmail(string email)
        {
            var user = _context.Users.Where(u => u.Email == email).Single();
            var accounts = _accountRepository.GetUserAccounts(user.UserId);
            user.userAccounts = accounts;

            return user;
        }
        /// <summary>
        /// Get all users in the database
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            // get the list of all users in a datatable
            var listUsers = _context.Users.Include(a => a.userAccounts).ToList();

            return listUsers;
        }
    }
}
