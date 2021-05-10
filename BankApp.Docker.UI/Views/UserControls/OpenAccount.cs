using BankApp.Docker.Core;
using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BankApp.UI.Views.UserControls
{
    public partial class OpenAccount : UserControl
    {
        //Fields
        private readonly User _user;
        private readonly IAccountRepository _accountRepository;
        private readonly IBankOperation _bankOperation;

        public OpenAccount(User user)
        {
            _bankOperation = GlobalConfig.BankOperation;
            _accountRepository = GlobalConfig.AccountRepository;
            _user = user;
            InitializeComponent();
        }

        private void OpenAccount_Load(object sender, EventArgs e)
        {
            if (_user.UserAccounts.Count > 1)
            {
                MessageBox.Show("You have 2 accounts already", "Warning", MessageBoxButtons.OK);
                ControlClass.ShowControl(new Dashboard( _user), this.Parent);
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ControlClass.ShowControl(new Dashboard( _user), this.Parent);
        }


        //Open an account
        private void btnOpenAccount_Click(object sender, EventArgs e)
        {
            try
            {
                var amount = Convert.ToDecimal(this.txtInitialDeposit.Text);
                if (_user.UserAccounts.Select(t => t).First().AccType == "savings")
                {
                    if (amount < 0)
                        throw new Exception("Deposit amount must be greater than zero");


                    var newAccount = new CurrentAccount();

                    //Create the initial transaction
                    var transaction = new Transaction() { AccountNumber = newAccount.AccountNumber, Amount = amount, Note = "Initial Deposit", Type = "Deposit" };
                    newAccount.Transactions.Add(transaction);


                    _accountRepository.AddAccount(newAccount, _user.UserId);
                }
                else
                {
                    if (amount < 1000)
                        throw new Exception("Minimum deposit for a Savings account is 1000");

                    var newAccount = new SavingsAccount();

                    //Create the initial transaction
                    var transaction = new Transaction() { AccountNumber = newAccount.AccountNumber, Amount = amount, Note = "Initial Deposit", Type = "Deposit" };
                    newAccount.Transactions.Add(transaction);


                    _accountRepository.AddAccount(newAccount, _user.UserId);
                }
                MessageBox.Show("Account opening Succesful", "Success", MessageBoxButtons.OK);
                ControlClass.ShowControl(new Dashboard( _user), this.Parent);
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter a valid amount for initial deposit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }


        }
    }
}
