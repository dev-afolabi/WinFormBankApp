using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankApp.Docker.Models
{
    // An enum to hold the transaction type.
    [Table("Transactions")]
    public class Transaction
    {
        //Properties
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public DateTime DateCreated { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }

        //Default constructor set date created and transaction Id
        public Transaction()
        {
            DateCreated = DateTime.Now;
            TransactionId = Guid.NewGuid().ToString();
        }

        //Chained constructor
        public Transaction(decimal amount, DateTime date, string note,string type)
        {
            DateCreated = date;
            Amount = amount;
            Note = note;
            Type = type;
        }
    }
}
