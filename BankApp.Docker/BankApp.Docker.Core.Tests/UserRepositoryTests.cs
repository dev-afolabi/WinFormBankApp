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
using System.Text.Json;

namespace BankApp.Docker.Core.Tests
{
    public class Tests
    {
        string usersJson = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName+"\\Users.json");
        DbContextOptionsBuilder<AppDbContext> optionsBuilder;
        AppDbContext context;
        List<User> usersList = new List<User>();

        [SetUp]
        public void Setup()
        {
            optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                                .UseInMemoryDatabase("Data Source=:memory:");
            context = new AppDbContext(optionsBuilder.Options);
            

            //insert Seed data
            if(context.Users.Count() < 1)
            {
                foreach (var item in GetSampleData())
                {
                    context.Add(item);
                    usersList.Add(item);
                }
                context.SaveChanges();
            }
            
        }



        [Test]
        public void GetUsers_whenCalled_returnsListOfUsers()
        {
            //Arrange
            using (context)
            {
                var mockAccRepo = new Mock<IAccountRepository>();
                mockAccRepo.Setup(x => x.GetUserAccounts("123244")).Returns(new List<Account>());
                var userRepo = new UserRepository(context, mockAccRepo.Object);

                var expected = usersList;
                var actual = userRepo.GetUsers();


                Assert.That(actual.Count, Is.EqualTo(expected.Count));
                Assert.That(actual, Is.Not.Null);
            }
            
        }


        [TestCase("will@gmail.com")]
        [TestCase("liljosh@gmail.com")]
        [TestCase("carl@gmail.com")]
        public void GetUserByEmail_CorrectUserEmail_returnsUser(string email)
        {
            using (context)
            {

                var mockAccRepo = new Mock<IAccountRepository>();
                mockAccRepo.Setup(x => x.GetUserAccounts("123244")).Returns(new List<Account>());

                var userRepo = new UserRepository(context, mockAccRepo.Object);


                var expected = email;
                var actual = userRepo.GetUserByEmail(email);

                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.Email, Is.EqualTo(expected));
            }
        }


        [TestCase("wrong@gmail.com")]
        public void GetUserByEmail_WrongtUserEmail_returnsNull(string email)
        {
            using (context)
            {

                var mockAccRepo = new Mock<IAccountRepository>();
                mockAccRepo.Setup(x => x.GetUserAccounts("123244")).Returns(new List<Account>());

                var userRepo = new UserRepository(context, mockAccRepo.Object);


                var expected = email;
                var actual = userRepo.GetUserByEmail(email);

                Assert.That(actual, Is.Null);
            }
        }

        [Test]
        public void AddUser_WhenCalled_returnsTrueOnAdd()
        {
            User newUser = new User() { Firstname = "Khalid", LastName = "Ridwan", Email = "also@gmail.com" };

            var userRepo = new UserRepository(context, null);

            var actual = userRepo.AddUser(newUser);
            usersList.Add(newUser);


            Assert.That(actual, Is.True);
            Assert.That(context.Users.Count(), Is.GreaterThan(GetSampleData().Count));
        }


        private List<User> GetSampleData()
        {
            var output = JsonSerializer.Deserialize<List<User>>(usersJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            return output;
        }
    }
}