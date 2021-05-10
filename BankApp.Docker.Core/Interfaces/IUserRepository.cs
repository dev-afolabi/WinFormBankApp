using BankApp.Docker.Models;
using System.Collections.Generic;

namespace BankApp.Docker.Core.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        bool AddUser(User user);
        User GetUserByEmail(string email);
    }
}
