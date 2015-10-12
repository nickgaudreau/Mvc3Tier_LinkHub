using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Hashing
    {
        private static string GetRandomSalt()
        {
            return "";//BCrypt.GenerateSalt(12);
        }
        public static string HashPassword(string plainTextPassword)
        {
            return "";// BCrypt.HashPassword(plainTextPassword, GetRandomSalt());
        }

        public static bool ValidatePassword(string plainTextPassword, string correctHash)
        {
            return true;// BCrypt.Verify(plainTextPassword, correctHash);
        }
    }
}
