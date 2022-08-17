using System.Security.Cryptography;

namespace ReDoPeAPI.Tools
{
    public static class PasswordHashing
    {
        public static string CreateHash(string password)
        {
            RNGCryptoServiceProvider csprng = new();
            byte[] salt = new byte[24];
            csprng.GetBytes(salt);

            byte[] hash = PBKDF2(password, salt, 1000, 24);
            return 1000 + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}
