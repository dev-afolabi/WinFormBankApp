using BankApp.Docker.Models;

namespace BankApp.Docker.Core.Interfaces
{
    public interface IAuthentication
    {
        bool Register(User user, string password);
        User Login(string email, string password);

    }
}
