using BankApp.Docker.Core;
using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.UI.Dto;
using BankApplication.Commons;
using System;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class frmRegister : Form
    {
        //Private injected fields
        private readonly IAuthentication _auth;
        private readonly IBankOperation _operation;
        UserInputs _userInputs = new UserInputs();



        public frmRegister()
        {
            _operation = GlobalConfig.BankOperation;
            _auth = GlobalConfig.Authentication;
            InitializeComponent();
        }


        private void frmRegister_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            if (!CheckPassword())
            {
                MessageBox.Show("Passwords Did not match");
            }
            else
            {
                _userInputs.FirstName = this.txtFname.Text;
                _userInputs.LastName = this.txtLname.Text;
                _userInputs.Email = this.txtEmail.Text;
                _userInputs.Password = this.txtPassword.Text;
                bool valid = false;

                if (CheckEmpty(_userInputs.FirstName, _userInputs.LastName, _userInputs.Email, _userInputs.Password))
                {
                    valid = true;
                    if (!Utility.IsEmailValid(_userInputs.Email))
                    {
                        valid = false;
                        MessageBox.Show("Invalid Email format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (valid)
                {
                    this.Hide();
                    frmAccountType _accountType = new frmAccountType(_userInputs);
                    _accountType.Show();
                }

            }
        }

        private bool CheckPassword()
        {
            if (this.txtPassword.Text != this.txtPassword1.Text)
                return false;
            return true;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {

        }
        private bool CheckEmpty(string fname, string lname, string email, string password)
        {
            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
