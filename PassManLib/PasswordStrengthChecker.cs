using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace PassManLib
{
    /// <summary>
    /// Provides functionality to check the strength of a password and verify if it is blacklisted.
    /// </summary>
    public static class PasswordStrengthChecker
    {
        /// <summary>
        /// Contains a set of blacklisted passwords loaded from a file.
        /// </summary>
        public static HashSet<string> blacklistedPasswords;

        /// <summary>
        /// Static constructor to initialize the blacklisted passwords from a file.
        /// </summary>
        static PasswordStrengthChecker()
        {
                string filePath = "millionpassword.txt";
                if (File.Exists(filePath))
                {
                    blacklistedPasswords = new HashSet<string>(File.ReadAllLines(filePath), StringComparer.OrdinalIgnoreCase);
                }
        }
        private const int minPasswordLength = 8;
        private static int upperCaseCount = 0;
        private static int numberCount = 0;
        private static int symbolCount = 0;
        private static int excessCharacters = 0;
        private static int comboBonus = 0;
        private static int onlyLowerPenalty = 0;
        private static int onlyNumberPenalty = 0;
        private static int score = 0;



        /// <summary>
        /// Checks if the given password is blacklisted.
        /// </summary>
        /// <param name="password">Password string.</param>
        /// <returns>True if the password is blacklisted; otherwise, false.</returns>

        private static bool IsBlacklistedPassword(string password)
        {
            return blacklistedPasswords != null && blacklistedPasswords.Contains(password);
        }

        /// <summary>
        /// Determines whether the specified password is strong.
        /// </summary>
        /// <param name="password">The password string to check.</param>
        /// <param name="message">Output message describing the strength of the password.</param>
        /// <param name="tip">Output message providing a tip if the password is not strong.</param>
        /// <returns>True if the password is strong; otherwise, false.</returns>
        public static bool IsStrong(string password, out string message, out string tip)
        {
            message = string.Empty;
            tip= string.Empty;

            if (IsBlacklistedPassword(password))
            {
                tip = "The password is blacklisted.";
                return false;
            }

            int score = CalculatePasswordScore(password);

            if (score < 50)
            {
                message = "Weak";
            }
            else if (score >= 50 && score < 75)
            {
                message = "Medium";
            }
            else if (score >= 75 && score < 100)
            {
                message = "Hard";
            }
            else if (score >= 100)
            {
                message = "Safe";            
            }

            return score >= 50;

        }

        /// <summary>
        /// Calculates the score of the specified password based on various criteria.
        /// </summary>
        /// <param name="password">The password string to score.</param>
        /// <returns>The score of the password.</returns>
        public static int CalculatePasswordScore(string password)
        {
            int upperCaseCount = 0;
            int numberCount = 0;
            int symbolCount = 0;
            int excessCharacters = password.Length - minPasswordLength;
            int comboBonus = 0;
            int onlyLowerPenalty = 0;
            int onlyNumberPenalty = 0;


            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    upperCaseCount++;
                }
                else if (char.IsDigit(c))
                {
                    numberCount++;
                }
                else if (Regex.IsMatch(c.ToString(), @"[!,@,#,$,%,^,&,*,?,_,~]"))
                {
                    symbolCount++;
                }           
            }

            if (upperCaseCount > 0 && numberCount > 0 && symbolCount > 0)
            {
                comboBonus = 25;
            }
            else if ((upperCaseCount > 0 && numberCount > 0) || (upperCaseCount > 0 && symbolCount > 0) || (numberCount > 0 && symbolCount > 0))
            {
                comboBonus = 15;
            }

            if (Regex.IsMatch(password, @"^[a-z\s]+$"))
            {
                onlyLowerPenalty = -15;
            }

            if (Regex.IsMatch(password, @"^[0-9\s]+$"))
            {
                onlyNumberPenalty = -35;
            }

            return excessCharacters * 2 + upperCaseCount * 4 + numberCount * 4 + symbolCount * 6 + comboBonus + onlyLowerPenalty + onlyNumberPenalty;
        }

    }
}
