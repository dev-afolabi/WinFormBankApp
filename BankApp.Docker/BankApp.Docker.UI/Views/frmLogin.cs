using BankApp.Docker.Core;
using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Models;
using BankApplication.Commons;
using System;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class frmLogin : Form
    {
        //fields
        private User _user = new User();
        private readonly IAuthentication _auth;


        //Constructor
        public frmLogin()
        {
            _auth = GlobalConfig.Authentication;
            InitializeComponent();
        }


        private void txtEmail_Click(object sender, EventArgs e)
        {

        }


        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            frmRegister reg = new frmRegister();
            reg.Show();
        }

        //form load options
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = this.txtEmail.Text;
            var password = this.txtPassword.Text;
            bool valid = false;
            if (CheckNotEmpty(email, password))
            {
                valid = true;
                if (!Utility.IsEmailValid(email))
                {
                    valid = false;
                    MessageBox.Show("Invalid Email format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (valid)
            {
                try
                {
                    _user = _auth.Login(email, password);
                    if (_user != null)
                    {
                        this.TopMost = false;
                        this.txtEmail.Text = "";
                        this.txtPassword.Text = "";
                        new frmDashboard(_user).Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }

        private bool CheckNotEmpty(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}
