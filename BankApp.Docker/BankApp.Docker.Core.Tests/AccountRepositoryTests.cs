using BankApp.Docker.Core.Interfaces;
using BankApp.Docker.Data;
using BankApp.Docker.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace BankApp.Docker.Core.Tests
{
    class AccountRepositoryTests
    {
        string accountJson = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Accounts.json");
        DbContextOptionsBuilder<AppDbContext> optionsBuilder;
        AppDbContext context;
        List<Account> accountList = new List<Account>();

        [SetUp]
        public void setup()
        {
            optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                                .UseInMemoryDatabase("Data Source=:memory:");
            context = new AppDbContext(optionsBuilder.Options);

            if (context.Accounts.Count() < 1)
            {
                foreach (var item in GetSampleData())
                {
                    context.Add(item);
                    accountList.Add(item);
                }
                context.SaveChanges();
            }
        }

        [TestCase("firstuser")]
        public void GetUserAccounts_WhenCalledWithValidId_ReturnsListOfAccounts(string id)
        {
            using (context)
            {
                var mockTransRepo = new Mock<ITransactionRepository>();
                mockTransRepo.Setup(x => x.GetTransactions("ytfuggfhj")).Returns(new List<Transaction>());


                var accountRepo = new AccountRepository(context, mockTransRepo.Object);

                var expected = accountList.Where(x => x.UserID == id).ToList();
                var actual = accountRepo.GetUserAccounts(id);

                Assert.That(actual.Count, Is.EqualTo(expected.Count));
                Assert.That(actual, Is.Not.Null);
            }
        }


        [TestCase("wronguser")]
        public void GetUserAccounts_WhenCalledWithInvalidId_ReturnsNull(string id)
        {

            using (context)
            {
                var mockTransRepo = new Mock<ITransactionRepository>();
                mockTransRepo.Setup(x => x.GetTransactions("ytfuggfhj")).Returns(new List<Transaction>());


                var accountRepo = new AccountRepository(context, mockTransRepo.Object);

                var expected = accountList.Where(x => x.UserID == id).ToList();
                var actual = accountRepo.GetUserAccounts(id);

                Assert.That(actual.Count, Is.EqualTo(0));
                Assert.That(actual, Is.Not.Null);
            }

        }

        [TestCase("12345")]
        public void GetAccountByNumber_WhenCalledWithValidAccountNumber_ReturnsAccount(string account)
        {
            using (context)
            {
               
                var accountRepo = new AccountRepository(context,null);

                var expected = accountList.Where(x => x.AccountNumber == account).ToList();
                var actual = accountRepo.GetAccountByNumber(account);

                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.AccountNumber == account);
            }
        }


        [TestCase("263678328")]
        public void GetAccountByNumber_WhenCalledWithInvalidAccountNumber_ReturnsNull(string account)
        {
            using (context)
            {

                var accountRepo = new AccountRepository(context, null);

                var expected = accountList.Where(x => x.AccountNumber == account).ToList();
                var actual = accountRepo.GetAccountByNumber(account);

                Assert.That(actual, Is.Null);
            }
        }

        [Test]
        public void AddAccount_WhenCalled_returnsTrueOnAdd()
        {
            Account newAccount = new Account() {AccountNumber = "28378282", AccType = "savings", UserID = "newuser"};

            var accountRepo = new AccountRepository(context, null);

            var actual = accountRepo.AddAccount(newAccount, newAccount.UserID);
            accountList.Add(newAccount);


            Assert.That(actual, Is.True);
            Assert.That(context.Accounts.Count(), Is.GreaterThan(GetSampleData().Count));
        }

        private List<Account> GetSampleData()
        {
            var output = JsonSerializer.Deserialize<List<Account>>(accountJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return output;
        }
    }
}
