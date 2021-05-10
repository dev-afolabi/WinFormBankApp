using BankApp.Docker.Core;
using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using System;
using System.Windows.Forms;

namespace BankApp.UI.Views.UserControls
{
    public partial class Withdraw : UserControl
    {
        //Fields
        private readonly IBankOperation _operation;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly User _user;


        public Withdraw(User user)
        {
            _operation = GlobalConfig.BankOperation;
            _accountRepository = GlobalConfig.AccountRepository;
            _transactionRepository = GlobalConfig.TransactionRepository;
            _user = user;
            InitializeComponent();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            //Initialize combo box values
            cboWithdraw.Items.Add("");
            foreach (var item in _user.UserAccounts)
            {
                this.cboWithdraw.Items.Add(item.AccountNumber);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            decimal amount = default;
            try
            {
                //Account to withdraw from
                var account = _accountRepository.GetAccountByNumber(cboWithdraw.Text);

                var transactions = _transactionRepository.GetTransactions(account.AccountNumber);

                account.Transactions = transactions;


                amount = decimal.Parse(this.txtAmount.Text);

                if (amount < 1)
                {
                    MessageBox.Show("Withdrawn amount must be greater than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (account.Balance - amount < account.MinimumBalance)
                {
                    MessageBox.Show("Insufficient funds", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var note = this.txtNote.Text;
                    var accountNumber = cboWithdraw.Text;

                    if (CheckEmpty(this.txtNote.Text, note, accountNumber))
                        throw new Exception("All fields are required");

                    _operation.MakeWithdrawal(accountNumber, amount, note, "Withdrawal");
                    MessageBox.Show("Withdraw was succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ControlClass.ShowControl(new Dashboard(_user), this.Parent);
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter a valid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an account to withdraw from", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClass.ShowControl(new Dashboard(_user), this.Parent);
        }


        //Check if values are empty
        private bool CheckEmpty(string amount, string accNum, string note)
        {
            if (string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(accNum) || string.IsNullOrEmpty(note))
                return true;
            return false;
        }
    }
}
