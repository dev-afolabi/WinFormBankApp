using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Data;
using BankApp.Docker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Docker.Core
{
    public class AccountRepository : IAccountRepository
    {
        //Privately injected fields
        private readonly ITransactionRepository _transactionRepository;
        private readonly AppDbContext _context;

        //Constructor
        public AccountRepository(AppDbContext context, ITransactionRepository transactionRepository)
        {
            _context = context;
            _transactionRepository = transactionRepository;
        }


        public bool AddAccount(Account account, string userId)
        {
            //Tie the account to user id
            account.UserID = userId;

            //save account
            _context.Accounts.Add(account);
            var res =_context.SaveChanges();

            return res > 0;
        }

        public Account GetAccountByNumber(string accountNumber)
        {
            var account = _context.Accounts.Include(a => a.Transactions)
                                            .Where(a => a.AccountNumber == accountNumber).SingleOrDefault();

            return account;
        }


        public List<Account> GetUserAccounts(string id)
        {

            // get the list of all users account
            var userAccounts = _context.Accounts.Where(a => a.UserID == id).ToList();
            foreach (var item in userAccounts)
            {
                item.Transactions = _transactionRepository.GetTransactions(item.AccountId);
            }

            return userAccounts;
        }
    }
}
