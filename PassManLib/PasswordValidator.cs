﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PassManLib
{
    public static class PasswordValidator
    {

        // <summary>
        /// Password complexity check: digit, upper case and lower case.
        /// </summary>
        /// <param name="password">Password string.</param>
        /// <returns>bool</returns>
        public static bool ValidatePassword(string password)
        {
            const string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{12,500}$";
            return !(string.IsNullOrEmpty(password) || CheckSpaceChar(password) || !Regex.IsMatch(password, patternPassword) || !SpecialCharCheck(password));
        }

        /// <summary>
        /// Hidding password imput for strings
        /// </summary>
        /// <returns></returns>
        public static SecureString GetHiddenConsoleInput()
        {
            var pwd = new SecureString();
            while (true)
            {
                var i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length <= 0) continue;
                    pwd.RemoveAt(pwd.Length - 1);
                    Console.Write("\b \b");
                }
                else if (i.KeyChar != '\u0000')
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }


        /// <summary>
        /// Check string for special character.
        /// </summary>
        /// <param name="input">Password string.</param>
        /// <returns></returns>
        private static bool SpecialCharCheck(string input)
        {
            return input.IndexOfAny(@"\|!#$%&/()=?»«@£§€{}.-;'<>_,".ToCharArray()) > -1;
        }

        /// <summary>
        /// Check for empty space in password.
        /// </summary>
        /// <param name="input">Password string.</param>
        /// <returns></returns>
        private static bool CheckSpaceChar(string input)
        {
            return input.Contains(" ");
        }

        /// <summary>
        /// Converts the secure string to string.
        /// </summary>
        /// <returns>The secure string to string.</returns>
        /// <param name="data">Data.</param>
        public static string ConvertSecureStringToString(this SecureString data)
        {
            return new System.Net.NetworkCredential(string.Empty, data).Password;
        }
        /// <summary>
        /// Convert string to secure string.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static SecureString StringToSecureString(string data)
        {
            var secureString = new SecureString();
            foreach (var c in data)
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }
    }
}
