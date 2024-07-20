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
    public static class PasswordStrengthChecker
    {
        public static HashSet<string> blacklistedPasswords;

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
        /// Checks if the password is blacklisted.
        /// </summary>
        /// <param name="password">Password string.</param>
        /// <returns>bool</returns>
        private static bool IsBlacklistedPassword(string password)
        {
            return blacklistedPasswords != null && blacklistedPasswords.Contains(password);
        }

        /// <summary>
        /// Checks if the password is strong and provides a message if it's not.
        /// </summary>
        /// <param name="password">Password string.</param>
        /// <param name="message">Output message describing the issue.</param>
        /// <returns>bool indicating if the password is strong.</returns>
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
