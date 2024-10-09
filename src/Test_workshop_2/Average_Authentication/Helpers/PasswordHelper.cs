using System.Security.Cryptography;
using System.Text;

namespace Average_Authentication.Helpers
{
    public static class PasswordHelper
    {
        // Генерация соли
        public static string GenerateSalt()
        {
           byte[] saltBytes = new byte[16];
            RandomNumberGenerator.Fill(saltBytes); // Новый метод для генерации случайных данных
            return Convert.ToBase64String(saltBytes);
        }

        // Хэширование пароля с солью
        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Проверка пароля
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            string hashOfInput = HashPassword(enteredPassword, storedSalt);
            return hashOfInput == storedHash;
        }
    }
}
