using BankApplication.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Docker.Models
{
    [Table("Users")]
    public class User
    {
        //Properties
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set
            {    // Validate firstname before setting it
                firstname = Utility.RemoveDigitFromStart(value.Trim());
                firstname = Utility.FirstCharacterToUpper(firstname);
            }
        }
        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set
            {   // Validate lastname before setting it
                lastname = Utility.RemoveDigitFromStart(value.Trim());
                lastname = Utility.FirstCharacterToUpper(lastname);
            }
        }

        // Return fullname
        public string Fullname
        {
            get { return lastname + ", " + firstname; }
        }


        public string Email { get; set; }
        //Save password hash
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        //Hold list of user accounts
        public virtual ICollection<Account> userAccounts { get; set; }


        //Default constructor sets the Date created and updates a new hashset
        public User()
        {
            userAccounts = new List<Account>();
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        //Constructor sets an account before instantiating with a chained call to the dedault
        //Constructor
        public User(string firstName,
                    string lastName,
                    string email
                    ):this()
        {
            Firstname = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
