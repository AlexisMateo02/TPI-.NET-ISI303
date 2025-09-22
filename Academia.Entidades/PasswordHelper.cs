using System.Security.Cryptography;
using System.Text;

public static class PasswordHelper
{
    private const string SecretSalt = "X7#kL9$mP2@qR5!tZ8&vW1*yC4"; // Salt secreto

    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password + SecretSalt);
            byte[] hashedBytes = sha256.ComputeHash(saltedPassword);
            return Convert.ToBase64String(hashedBytes);
        }
    }

    public static bool VerifyPassword(string inputPassword, string storedHash)
    {
        string hashOfInput = HashPassword(inputPassword);
        return hashOfInput == storedHash;
    }
}