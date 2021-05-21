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
    class AuthenticationTests
    {
        string authUsersJson = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Users.json");
        DbContextOptionsBuilder<AppDbContext> optionsBuilder;
        AppDbContext context;
        List<User> authUsersList = new List<User>();

        [SetUp]
        public void setup()
        {
            optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                                .UseInMemoryDatabase("Data Source=:memory:");
            context = new AppDbContext(optionsBuilder.Options);


            //insert Seed data
            if (context.Users.Count() < 1)
            {
                foreach (var item in GetSampleData())
                {
                    context.Add(item);
                    authUsersList.Add(item);
                }
                context.SaveChanges();
            }
        }

        [TearDown]
        public void teardown()
        {
            context.Database.EnsureDeleted();
        }

        [TestCase("will@gmail.com")]
        public void EmailExist_IfEmailInDatabase_ReturnsTrue(string email)
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUsers()).Returns(GetSampleData());

            var auth = new Authentication(userRepoMock.Object);

            var actual = auth.EmailExist(email);

            Assert.That(actual, Is.True);
        }


        [TestCase("wrong@gmail.com")]
        public void EmailExist_IfEmailNotInDatabase_ReturnsFalse(string email)
        {
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetUsers()).Returns(GetSampleData());

            var auth = new Authentication(userRepoMock.Object);

            var actual = auth.EmailExist(email);

            Assert.That(actual, Is.False);
        }



        private List<User> GetSampleData()
        {
            var output = JsonSerializer.Deserialize<List<User>>(authUsersJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return output;
        }
    }
}
