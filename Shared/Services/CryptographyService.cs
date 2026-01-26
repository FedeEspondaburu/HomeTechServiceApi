using Shared.Interfaces;
using System.Security.Cryptography;

namespace Shared.Services
{
    public class CryptographyService : ICryptographyService
    {
        public string EncryptPassword(string password)
        {
            //I will use pbkdf2 to encrypt the password
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            int iterations = 100_000;

            var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256
            );
            byte[] hash = pbkdf2.GetBytes(32);

            string storedPassword =
                $"PBKDF2$SHA256${iterations}$" +
                $"{Convert.ToBase64String(salt)}$" +
                $"{Convert.ToBase64String(hash)}";
            return storedPassword;
        }

        public bool VerifyPassword(string inputPassword, string stored)
        {
            var parts = stored.Split('$');

            int iterations = int.Parse(parts[2]);
            byte[] salt = Convert.FromBase64String(parts[3]);
            byte[] storedHash = Convert.FromBase64String(parts[4]);

            var pbkdf2 = new Rfc2898DeriveBytes(
                inputPassword,
                salt,
                iterations,
                HashAlgorithmName.SHA256
            );

            byte[] computedHash = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(
                computedHash,
                storedHash
            );
        }
    }
}
