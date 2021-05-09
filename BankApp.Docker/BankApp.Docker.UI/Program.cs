
using BankApp.Docker.Core;
using BankApp.Docker.UI;
using System;
using System.Windows.Forms;

namespace BankApp.UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalConfig.AddIinstance();
            Application.Run(new frmLogin());
        }
    }
}
