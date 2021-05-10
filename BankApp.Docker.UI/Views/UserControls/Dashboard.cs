using BankApp.Docker.Core;
using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class Dashboard : UserControl
    {
        //Fields
        private readonly IAccountRepository _accountRepository;
        private readonly User _user;
        private readonly ITransactionRepository _transactionRepository;
        public Dashboard(User user)
        {
            _accountRepository = GlobalConfig.AccountRepository;
            _transactionRepository = GlobalConfig.TransactionRepository;
            _user = user;
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            _user.UserAccounts = _accountRepository.GetUserAccounts(_user.UserId);
            if (_user.UserAccounts.Count > 1)
            {
                foreach (var item in _user.UserAccounts)
                {
                    if (item.AccType == "savings")
                    {
                        this.lblSaveAccNo.Text = item.AccountNumber.ToString();
                        this.lblSavingsBal.Text = _transactionRepository.GetTransactions(this.lblSaveAccNo.Text).Select(t => t.Amount).Sum().ToString();
                        
                    }

                    if (item.AccType == "current")
                    {
                        this.lblCurrentAccNo.Text = item.AccountNumber.ToString();
                        this.lblCurrentBal.Text = _transactionRepository.GetTransactions(this.lblCurrentAccNo.Text).Select(t => t.Amount).Sum().ToString();
                    }
                }
            }
            else
            {

                if (_user.UserAccounts.Select(a => a).Single().AccType == "savings")
                {
                    HideCurrent();

                    this.lblSaveAccNo.Text = _user.UserAccounts.Select(a => a).Single().AccountNumber.ToString();
                    this.lblSavingsBal.Text = _transactionRepository.GetTransactions(this.lblSaveAccNo.Text).Select(t => t.Amount).Sum().ToString();

                }

                if (_user.UserAccounts.Select(a => a).Single().AccType == "current")
                {
                    HideSavings();

                    this.lblCurrentAccNo.Text = _user.UserAccounts.Select(a => a).Single().AccountNumber.ToString();
                    this.lblCurrentBal.Text = _transactionRepository.GetTransactions(this.lblCurrentAccNo.Text).Select(t => t.Amount).Sum().ToString();
                }   

            }

            try
            {
                if(_user.UserAccounts.Count> 1)
                {
                    var accountList = _transactionRepository.GetRecentTransactions(_user.UserAccounts.Select(a => a.AccountNumber).ToList());
                    this.transactionsGrid.DataSource = accountList;
                    this.transactionsGrid.Columns["AccountNumber"].Visible = false;
                    this.transactionsGrid.Columns["TransactionId"].Visible = false;
                    this.transactionsGrid.Columns["AccountId"].Visible = false;
                    this.transactionsGrid.Columns["Account"].Visible = false;
                }
               

            }
            catch (NullReferenceException ex)
            {

                MessageBox.Show(ex.Message, "warning",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void HideCurrent()
        {
            this.lblCurrentBal.Visible = false;
            this.lblCurrentAccNo.Visible = false;
            this.crtBalLbl.Visible = false;
            this.crtNumLbl.Visible = false;
        }
        private void HideSavings()
        {
            this.lblSaveAccNo.Visible = false;
            this.lblSavingsBal.Visible = false;
            this.savBalLba.Visible = false;
            this.savinAcLbl.Visible = false;
        }
    }
}
