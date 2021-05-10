using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Docker.Models
{
    public class SavingsAccount : Account
    {
        //set minimum balance
        public override decimal MinimumBalance { get; } = 1000m;
        //Set account type
        public override string AccType { get; set; } = "savings";
        public override string ToString()
        {
            return "Savings Account";
        }
    }
}
