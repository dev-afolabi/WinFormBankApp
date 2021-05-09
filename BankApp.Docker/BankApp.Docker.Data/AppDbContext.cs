using BankApp.Docker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Docker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\hp\Decagon_Tasks\week7-dev-afolabi\BankApp.Docker\BankApp.Docker.Data\BankApplication.db;Cache=Shared");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<SavingsAccount> SavingsAccounts { get; set; }
        public DbSet<CurrentAccount> CurrentAccounts { get; set; }
    }
}
