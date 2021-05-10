using BankApp.Docker.Data;
using BankApp.Docker.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace BankApp.Docker.Core.Tests
{
    class TransactionRepositoryTests
    {
        string transactJson = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Transact.json");
        DbContextOptionsBuilder<AppDbContext> optionsBuilder;
        AppDbContext context;
        List<Transaction> transactList = new List<Transaction>();


        [SetUp]
        public void setup()
        {
            optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                                .UseInMemoryDatabase("Data Source=:memory:");
            context = new AppDbContext(optionsBuilder.Options);


            //insert Seed data
            if (context.Transactions.Count() < 1)
            {
                foreach (var item in GetSampleData())
                {
                    context.Add(item);
                    transactList.Add(item);
                }
                context.SaveChanges();
            }
        }



        [TestCase("12345")]
        public void GetTransactions_WhenCalledWithValidAccountNumber_ReturnsTransactions(string account)
        {
            using (context)
            {
                var accountRepo = new TransactionRepository(context);

                var expected = transactList.Where(x => x.AccountNumber == account).ToList();
                var actual = accountRepo.GetTransactions(account);

                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.Select(x => x.AccountNumber).Contains(account), Is.True);
            }
        }

        [TestCase("123q32i45")]
        public void GetTransactions_WhenCalledWithInvalidAccountNumber_ReturnsEmptyList(string account)
        {
            using (context)
            {
                var accountRepo = new TransactionRepository(context);

                var expected = transactList.Where(x => x.AccountNumber == account).ToList();
                var actual = accountRepo.GetTransactions(account);

                Assert.That(actual, Is.Empty);
               
            }
        }

        [Test]
        public void AddTransaction_WhenCalled_ReturnsTrueOnSuccess()
        {
            using (context)
            {
                var accountRepo = new TransactionRepository(context);
                var newTransaction = new Transaction();
                

                var actual = accountRepo.AddTransaction(newTransaction);

                Assert.That(actual, Is.True);
            }
        }


        private List<Transaction> GetSampleData()
        {
            var output = JsonSerializer.Deserialize<List<Transaction>>(transactJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return output;
        }


    }
}
