using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using BankApplication.Commons;
using System;

namespace BankApp.Docker.Core
{
    public class Authentication : IAuthentication
    {
        IUserRepository _userRepository;
        public Authentication( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Register(User user, string password)
        {

            // check if email already exist
            if (EmailExist(user.Email))
                throw new Exception("Email already exists");

            // generate password hash
            var hashes = Utility.GenerateHash(password);
            user.PasswordHash = hashes[0];
            user.PasswordSalt = hashes[1];

            // add user to data source
            if (_userRepository.AddUser(user))
            {
                return true;
            }
            return false;
        }

        // email exists
        public bool EmailExist(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var users = _userRepository.GetUsers();
                if (users == null)
                    return false;

                foreach (var row in users)
                {
                    if (row.Email == email)
                        return true;
                }
            }
            return false;
        }

        // validate login credentials
        private bool IsValidCredential(string email, string password)
        {
            bool passwordMatch = true;

            // check if user table contains records
            if (_userRepository.GetUsers().Count < 1)
            {
                throw new Exception("No record found");
            }

            // get user by email
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                passwordMatch = false;
                return passwordMatch;
            }
            if (user.Email == email)
            {
                if (!Utility.CompareHash(user.PasswordSalt, user.PasswordHash, password))
                {
                    passwordMatch = false;
                    return passwordMatch;
                }
            }
            else
            {
                return false;
            }

            return passwordMatch;
        }

        /// <summary>
        /// Login and return a user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string email, string password)
        {

            if (!IsValidCredential(email, password))
                throw new Exception("Invalid credentials");

            var user = _userRepository.GetUserByEmail(email);

            return user;
        }
    }
}
