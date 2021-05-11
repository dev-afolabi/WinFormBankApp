using BankApp.Docker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankApp.Docker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //public AppDbContext()
        //{

        //}
        //string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\BankApp.db";

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{

        //    //options.UseSqlite($"Data Source={path};Cache=Shared");
        //    options.UseSqlite(@"Data Source=C:\Users\hp\Decagon_Tasks\week7-dev-afolabi\BankApp.Docker\BankApp.Docker.Data\BankApp.db;Cache=Shared");
        
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<SavingsAccount> SavingsAccounts { get; set; }
        public DbSet<CurrentAccount> CurrentAccounts { get; set; }
    }
}
