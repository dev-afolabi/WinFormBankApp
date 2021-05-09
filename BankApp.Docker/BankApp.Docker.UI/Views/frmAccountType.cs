using BankApp.Docker.Core;
using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using BankApp.Docker.UI.Dto;
using System;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class frmAccountType : Form
    {
        //fields

        UserInputs _userInputs;
        private readonly IAuthentication _auth;
        private readonly IBankOperation _operation;
        public frmAccountType(UserInputs userInputs)
        {
            _userInputs = userInputs;
            _operation = GlobalConfig.BankOperation;
            _auth = GlobalConfig.Authentication;
            InitializeComponent();
        }

        private void frmAccountType_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Firstname = _userInputs.FirstName,
                LastName = _userInputs.LastName,
                Email = _userInputs.Email,

            };

            decimal amount = default;

            try
            {
                if (this.rdioCurrent.Checked)
                {
                    if (string.IsNullOrEmpty(txtDeposit.Text))
                        throw new Exception("Please input a positive value for amount");

                    amount = decimal.Parse(txtDeposit.Text);

                    if (amount < 0)
                        throw new InvalidOperationException("Amount must be greater than zero");


                    var newAccount = new CurrentAccount();

                    //Create the initial transaction
                    var transaction = new Transaction() { AccountNumber = newAccount.AccountNumber, Amount = amount, Note = "Initial Deposit", Type = "Deposit"};
                    newAccount.Transactions.Add(transaction);

                    user.userAccounts.Add(newAccount);
                    _auth.Register(user, _userInputs.Password);
                    MessageBox.Show("Your Registeration was successfull", "Successful", MessageBoxButtons.OK);
                    this.Hide();
                }
                else if(this.rdioSavings.Checked)
                {
                    if (string.IsNullOrEmpty(txtDeposit.Text))
                        throw new Exception("Please input a positive value for amount");

                    amount = decimal.Parse(txtDeposit.Text);

                    if (amount < 1000)
                        throw new InvalidOperationException("Minimum deposit for a savings account is 1000");

                    var newAccount = new SavingsAccount();

                    //Create the initial transaction
                    var transaction = new Transaction() { AccountNumber = newAccount.AccountNumber, Amount = amount, Note = "Initial Deposit", Type = "Deposit" };
                    newAccount.Transactions.Add(transaction);


                    user.userAccounts.Add(newAccount);
                    _auth.Register(user, _userInputs.Password);
                    MessageBox.Show("Your Registeration was successfull", "Successful", MessageBoxButtons.OK);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please select an account type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter valid input for amount", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
