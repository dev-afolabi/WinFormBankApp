using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankApp.Docker.Models
{
    [Table("Accounts")]
    public abstract class Account
    {
        //Properties
        public string AccountId { get; set; } = Guid.NewGuid().ToString();
        private static readonly Random rnd = new Random();
        public string AccountNumber { get; set; }
        public virtual decimal MinimumBalance { get; } = 0m;
        public string UserID { get; set; }
        public User User { get; set; }
        public virtual string AccType { get; set; }

        //Get balance from sum of transactions
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in Transactions)
                {
                    balance += item.Amount;  //This return the balance by summing every amount in the transaction
                }
                return balance;
            }
        }

        // A list to hold all the transactions
        public virtual ICollection<Transaction> Transactions { get; set; }


        //Create a random account number
        public Account()
        {
            Transactions = new List<Transaction>();

            AccountNumber = rnd.Next(1000000000, 1234567890).ToString();//Generate random number for account
        }
    }
}
