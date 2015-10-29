namespace DAL
{
    public class Hashing
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(10);
        }
        public static string HashPassword(string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword, GetRandomSalt());
        }

        public static bool ValidatePassword(string plainTextPassword, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, correctHash);
        }

    }
}
