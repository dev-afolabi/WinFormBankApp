using BankApp.Docker.Core;
using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using System;
using System.Windows.Forms;

namespace BankApp.UI.Views.UserControls
{
    public partial class AccountStatement : UserControl
    {
        //Fields
        private readonly ITransactionRepository _transactionRepository;
        User _user;


        public AccountStatement(User user)
        {
            _user = user;
            _transactionRepository = GlobalConfig.TransactionRepository;
            InitializeComponent();
        }

        private void AccountStatement_Load(object sender, EventArgs e)
        {
            cboAccounts.Items.Add("");
            foreach (var item in _user.UserAccounts)
            {
                this.cboAccounts.Items.Add(item.AccountNumber);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClass.ShowControl(new Dashboard(_user), this.Parent);
        }

        private void btnViewStatement_Click(object sender, EventArgs e)
        {
            var accountNumber = this.cboAccounts.Text;

            try
            {
                if (string.IsNullOrEmpty(accountNumber))
                    throw new Exception("Please select account to view");

                var accountList = _transactionRepository.GetTransactions(accountNumber);


                this.dtgStatement.DataSource = accountList;
                this.dtgStatement.Columns["AccountNumber"].Visible = false;
                this.dtgStatement.Columns["TransactionId"].Visible = false;
                this.dtgStatement.Columns["AccountId"].Visible = false;
                this.dtgStatement.Columns["Account"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "warning", MessageBoxButtons.OK);
            }
            

        }
    }
}
