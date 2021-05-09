using System.Collections.Generic;
using BankApp.Docker.Models;

namespace BankApp.Docker.Core.Interfaces
{
    public interface ITransactionRepository
    {
        List<Transaction> GetTransactions(string accountNumber);
        List<Transaction> GetRecentTransactions(List<string> accountNums);
        bool AddTransaction(Transaction transaction);
    }
}
