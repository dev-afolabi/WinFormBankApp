using BankApp.Docker.Core;
using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using System;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class Deposit : UserControl
    {
        //private injected variable
        private readonly IBankOperation _operation;
        private readonly User _user;
        public Deposit(User user)
        {
            _operation = GlobalConfig.BankOperation;
            _user = user;
            InitializeComponent();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            cboAccountSelect.Items.Add("");
            foreach (var item in _user.UserAccounts)
            {
                this.cboAccountSelect.Items.Add(item.AccountNumber);
            }

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            decimal amount = default;
            try
            {
                amount = decimal.Parse(this.txtAmount.Text);
                if (amount < 1)
                {
                    MessageBox.Show("Deposit must be greater than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var note = this.txtNote.Text;
                    var accountNumber = cboAccountSelect.Text;

                    if (CheckEmpty(this.txtNote.Text,note,accountNumber))
                        throw new Exception("All fields are required");

                    _operation.MakeDeposit(accountNumber, amount, note, "Deposit");
                    MessageBox.Show("Deposit was succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ControlClass.ShowControl(new Dashboard( _user), this.Parent);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
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
