using BankApp.Docker.Core.Interfaces;
using System.Windows.Forms;

namespace BankApp.UI
{
    public class ControlClass
    {
        private readonly IAccountRepository accountRepository;


        public ControlClass(IAccountRepository repo)
        {
            accountRepository = repo;
        }


        public static void ShowControl(Control control, Control Content)
        {
            Content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            Content.Controls.Add(control);
        }
    }
}
