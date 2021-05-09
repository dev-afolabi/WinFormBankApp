using BankApp.Docker.Models;
using System.Collections.Generic;

namespace BankApp.Docker.Core.Interfaces
{
    public interface IAccountRepository
    {
        bool AddAccount(Account account, string userId);
        List<Account> GetUserAccounts(string id);

        Account GetAccountByNumber(string accountNumber);
    }
}
