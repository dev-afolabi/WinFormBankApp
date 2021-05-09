using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using System;

namespace BankApp.Docker.Core
{
    public class BankOperation : IBankOperation
    {
        //Private injected fileds
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;


        //Constructor
        public BankOperation()
        {
            _transactionRepository = GlobalConfig.TransactionRepository;
            _accountRepository = GlobalConfig.AccountRepository;

        }


        /// <summary>
        /// Make Deposit
        /// </summary>
        /// <param name="accountNo"></param>
        /// <param name="amount"></param>
        /// <param name="note"></param>
        /// <param name="type"></param>
        public void MakeDeposit(string accountNo, decimal amount, string note, string type)
        {
            var transaction = new Transaction
            {
                Amount = amount,
                AccountNumber = accountNo,
                Note = note,
                Type = type,
            };
            _transactionRepository.AddTransaction(transaction);
        }

        /// <summary>
        /// Transfer to self and third party
        /// </summary>
        /// <param name="accountSender"></param>
        /// <param name="accountReciever"></param>
        /// <param name="amount"></param>
        /// <param name="note"></param>
        /// <param name="type"></param>
        public void MakeTransfer(string accountSender, string accountReceiver, decimal amount)
        {
            if (_accountRepository.GetAccountByNumber(accountReceiver) == null)
                throw new ArgumentException("Account does not exist");

            var debitTransaction = new Transaction { AccountNumber = accountSender, DateCreated = DateTime.Now, Amount = -amount, Type = "debit", Note = "debit" };
            var creditTransaction = new Transaction { AccountNumber = accountReceiver, DateCreated = DateTime.Now, Amount = amount, Type = "credit", Note = "credit" };
            _transactionRepository.AddTransaction(debitTransaction);
            _transactionRepository.AddTransaction(creditTransaction);
        }

        /// <summary>
        /// Make withdraw
        /// </summary>
        /// <param name="accountNo"></param>
        /// <param name="amount"></param>
        /// <param name="note"></param>
        /// <param name="type"></param>
        public void MakeWithdrawal(string accountNo, decimal amount, string note, string type)
        {
            var transaction = new Transaction
            {
                Amount = -amount,
                AccountNumber = accountNo,
                Note = note,
                Type = type
            };
            _transactionRepository.AddTransaction(transaction);
        }
    }
}
