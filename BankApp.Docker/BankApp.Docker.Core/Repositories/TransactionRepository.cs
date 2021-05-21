using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Data;
using BankApp.Docker.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Docker.Core
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;


        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }


        public bool AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            var res = _context.SaveChanges();

            return res > 0;
        }

        public List<Transaction> GetRecentTransactions(List<string> accountNums)
        {
            // get the list of all transaction in the datataable
            var listTransactions = _context.Transactions.Where(a => a.AccountNumber == accountNums[0] || a.AccountNumber == accountNums[1])
                                                        .OrderByDescending(d => d.DateCreated).Take(5).ToList();

            return listTransactions;
        }


        public List<Transaction> GetTransactions(string accountNumber)
        {
            // get the list of all transaction in the datataable
            var listTransaction = _context.Transactions.Where(a => a.AccountNumber == accountNumber).ToList();

            return listTransaction;
        }
    }
}
