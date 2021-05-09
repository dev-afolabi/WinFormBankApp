using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace BankApplication.Commons
{
    public static class Utility
    {
        // Clean string to remove digit at the begining
        public static string RemoveDigitFromStart(string val)
        {
            var str = val.Substring(0, 1).ToCharArray();
            var strCode = (int)str[0];
            if (strCode >= 48 && strCode <= 57)
            {
                return RemoveDigitFromStart(val.Substring(1));
            }

            return val;
        }

        // Change first character to caps
        public static string FirstCharacterToUpper(string val)
        {
            var str = val.Substring(0, 1).ToCharArray();
            var strCode = (int)str[0];
            if (strCode >= 97)
            {
                var strCaps = strCode - 32;
                return (char)strCaps + val.Substring(1);
            }

            return val;
        }
        // Validates received email
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Checks if value is within range
        private static bool IsWithinRange(int value, int minValue, int maxValue)
        {
            if(value >= minValue && value <= maxValue)
            {
                return true;
            }
            return false;
        }

        // Validate inputed value
        public static bool IsValid(string input, int minValue, int maxValue)
        {   
            int value;
            bool success = int.TryParse(input, out value);
            if(success)
            {
                if(!IsWithinRange(value,minValue,maxValue))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\nPlease Input a number between {minValue} and {maxValue}: ");
                    Console.ResetColor();
                    success = false;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nPlease Input a valid number: " );
                Console.ResetColor();
            }
            return success;
        }

        // Generate hash
        public static List<byte[]> GenerateHash(string password)
        {
            byte[] passwordSalt, passwordHash;

            // convert password to hash value and generate salt
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hash.Key;
                passwordHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            var result = new List<byte[]>();
            result.Add(passwordHash);
            result.Add(passwordSalt);

            return result;
        }


        // compare password hash
        public static bool CompareHash(byte[] passwordSalt, byte[] passwordHash, string password)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var hashGenerated = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < hashGenerated.Length; i++)
                {
                    if (hashGenerated[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // validate email

        public static bool IsEmailValid(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return true;
            else
                return false;
        }
    }
}