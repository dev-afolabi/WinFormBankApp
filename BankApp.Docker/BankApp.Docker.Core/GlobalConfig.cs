using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Data;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Docker.Core
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Setup the global instance of all repositories
        /// </summary>
        public static IUserRepository UserRepository { get; private set; }
        public static IAuthentication Authentication { get; private set; }
        public static IBankOperation BankOperation { get; private set; }
        public static IAccountRepository AccountRepository { get; private set; }
        public static ITransactionRepository TransactionRepository { get; private set; }

        public static void AddIinstance()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(@"Data Source=C:\Users\hp\Decagon_Tasks\week7-dev-afolabi\BankApp.Docker\BankApp.Docker.Data\BankApplication.db;Cache=Shared");


            var _ctx = new AppDbContext(optionsBuilder.Options);
            TransactionRepository = new TransactionRepository(_ctx);
            AccountRepository = new AccountRepository(_ctx);
            UserRepository = new UserRepository(_ctx,AccountRepository);
            Authentication = new Authentication();
            BankOperation = new BankOperation();
        }

        public static void RemoveIinstance()
        {
            //Iinstance = null;
        }
    }
}
