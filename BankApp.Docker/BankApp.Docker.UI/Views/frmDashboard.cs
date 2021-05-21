using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using BankApp.UI.Views.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class frmDashboard : Form
    {
        //Fields
        private Button currentButton;
        User _user;


        public Panel panelController
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

        //Constructor
        public frmDashboard(User user)
        {
            _user = user;
            InitializeComponent();

        }


        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.lblFullname.Text = _user.Fullname;

            Dashboard dash = new Dashboard(_user);
            dash.Dock = DockStyle.Fill;

            panelContainer.Controls.Add(dash);
            ControlClass.ShowControl(dash, panelController);
        }


        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = ColorTranslator.FromHtml("#24244F");
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control prevButton in panelMenu.Controls)
            {
                if (prevButton.GetType() == typeof(Button))
                {
                    prevButton.BackColor = Color.FromArgb(34, 36, 49);
                }
            }
        }

        private void btnOpenAccount_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenAccount openAccount = new OpenAccount( _user);
            panelController.Controls.Clear();
            ControlClass.ShowControl(openAccount, panelController);

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            Deposit deposit = new Deposit(_user);
            ControlClass.ShowControl(deposit, panelController);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            panelController.Controls.Clear();
            Withdraw withdraw = new Withdraw(_user);
            ControlClass.ShowControl(withdraw, panelController);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            panelController.Controls.Clear();
            Transfer transfer = new Transfer(_user);
            ControlClass.ShowControl(transfer, panelController);
        }

        private void btnStatement_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            panelController.Controls.Clear();
            AccountStatement statement = new AccountStatement(_user);
            ControlClass.ShowControl(statement, panelController);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
