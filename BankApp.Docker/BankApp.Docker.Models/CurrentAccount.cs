namespace BankApp.Docker.Models
{
    public class CurrentAccount : Account
    {
        //Set account type
        public override string AccType { get; set; } = "current";
        public override string ToString()
        {
            return "Current Account";
        }
    }
}
