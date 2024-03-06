using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace Job.Notes.Application.Security;

public static class HashService
{
    public static string GenerateSha256Hash(string word)
    {
        var salt = GenerateRandomSalt();
        var wordBytes = Encoding.UTF8.GetBytes(word);
        
        var saltedPasswordBytes = new byte[wordBytes.Length + salt.Length];
        Array.Copy(wordBytes, saltedPasswordBytes, wordBytes.Length);
        Array.Copy(salt, 0, saltedPasswordBytes, wordBytes.Length, salt.Length);
        
        using (var sha256 = SHA256.Create())
        {
            var hashBytes = sha256.ComputeHash(saltedPasswordBytes);

            var builder = new StringBuilder();
            builder.Append(Convert.ToBase64String(salt));
            builder.Append(':');
            builder.Append(Convert.ToBase64String(hashBytes));

            return builder.ToString();
        }
    }
    
    public static bool VerifyHash(string password, string hashedPassword)
    {
        string[] parts = hashedPassword.Split(':');
        var storedSalt = Convert.FromBase64String(parts[0]);
        
        var storedHash = Convert.FromBase64String(parts[1]);
        
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var saltedPasswordBytes = new byte[passwordBytes.Length + storedSalt.Length];
        Array.Copy(passwordBytes, saltedPasswordBytes, passwordBytes.Length);
        Array.Copy(storedSalt, 0, saltedPasswordBytes, passwordBytes.Length, storedSalt.Length);

        using (var sha256 = SHA256.Create())
        {
            var hashBytes = sha256.ComputeHash(saltedPasswordBytes);
            return StructuralComparisons.StructuralEqualityComparer.Equals(hashBytes, storedHash);
        }
    }
    
    private static byte[] GenerateRandomSalt()
    {
        var salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        
        return salt;
    }
}