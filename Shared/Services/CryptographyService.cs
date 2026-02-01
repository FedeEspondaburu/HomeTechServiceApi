using Shared.Interfaces;
using System.Security.Cryptography;

namespace Shared.Services
{
    public class CryptographyService : ICryptographyService
    {
        //EncryptMethod = "PBKDF2$SHA256$";
        private const int encryptIterations = 100000;
        public string EncryptPassword(string password)
        {
            //I will use pbkdf2 to encrypt the password
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                encryptIterations,
                HashAlgorithmName.SHA256
            );
            byte[] hash = pbkdf2.GetBytes(32);

            string storedPassword =
                $"{Convert.ToBase64String(salt)}$" +
                $"{Convert.ToBase64String(hash)}";
            return storedPassword;
        }

        public bool VerifyPassword(string inputPassword, string stored)
        {
            var parts = stored.Split('$');
            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHash = Convert.FromBase64String(parts[1]);

            var pbkdf2 = new Rfc2898DeriveBytes(
                inputPassword,
                salt,
                encryptIterations,
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
