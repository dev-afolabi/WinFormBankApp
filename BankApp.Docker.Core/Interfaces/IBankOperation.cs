namespace BankApp.Docker.Core.Interfaces
{
    public interface IBankOperation
    {
        void MakeDeposit(string accountNo, decimal amount, string note, string type);
        void MakeWithdrawal(string accountNo, decimal amount, string note, string type);
        void MakeTransfer(string accountSender, string accountReciever, decimal amount);
    }
}
