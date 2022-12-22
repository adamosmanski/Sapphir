using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Core
{
    public static class UniquePassword
    {
        public static string GeneratePassword()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            const int passwordLength = 16;
            const int minUpperCaseChars = 2;
            const int minLowerCaseChars = 2;
            const int minNumericChars = 2;
            const int minSpecialChars = 2;

            StringBuilder password = new StringBuilder();
            Random random = new Random();
            int upperCaseChars = 0;
            int lowerCaseChars = 0;
            int numericChars = 0;
            int specialChars = 0;

            while (password.Length < passwordLength)
            {
                int index = random.Next(validChars.Length);
                char c = validChars[index];

                if (char.IsUpper(c))
                {
                    upperCaseChars++;
                }
                else if (char.IsLower(c))
                {
                    lowerCaseChars++;
                }
                else if (char.IsNumber(c))
                {
                    numericChars++;
                }
                else
                {
                    specialChars++;
                }
                password.Append(c);
                if (upperCaseChars >= minUpperCaseChars && lowerCaseChars >= minLowerCaseChars &&
                    numericChars >= minNumericChars && specialChars >= minSpecialChars)
                {
                    break;
                }
            }
            return password.ToString();
        }
    }
}
