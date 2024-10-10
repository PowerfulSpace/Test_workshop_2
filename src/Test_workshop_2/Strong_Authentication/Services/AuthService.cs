using Strong_Authentication.Data;
using Strong_Authentication.Helpers;
using Strong_Authentication.Models;

namespace Strong_Authentication.Services
{
    public class AuthService
    {
        // Регистрация пользователя с ролью
        public static void Register(string username, string password, string role = "User")
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Users.Any(u => u.Username == username))
                {
                    Console.WriteLine("Пользователь с таким именем уже существует.");
                    return;
                }

                string salt = PasswordHelper.GenerateSalt();
                string passwordHash = PasswordHelper.HashPassword(password, salt);

                User newUser = new User
                {
                    Id = Guid.NewGuid(),
                    Username = username,
                    PasswordHash = passwordHash,
                    Salt = salt,
                    Role = role
                };

                db.Users.Add(newUser);
                db.SaveChanges();
                Console.WriteLine($"Пользователь {username} с ролью {role} успешно зарегистрирован.");
            }
        }

        // Аутентификация пользователя
        public static string? Authenticate(string username, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Username == username)!;

                if (user == null)
                {
                    Console.WriteLine("Пользователь не найден.");
                    return null;
                }

                if (!PasswordHelper.VerifyPassword(password, user.PasswordHash, user.Salt))
                {
                    Console.WriteLine("Неверный пароль.");
                    return null;
                }

                Console.WriteLine($"Успешная аутентификация. Роль: {user.Role}");

                // Генерируем JWT-токен
                string token = JwtHelper.GenerateToken(user.Username, user.Role);

                // Логируем успешную аутентификацию
                LoggingService.Log($"Пользователь {user.Username} успешно аутентифицирован.");

                return token;
            }
        }

        // Получение пользователя из токена
        public static User? GetUserFromToken(string token)
        {
            var principal = JwtHelper.GetPrincipal(token);

            if (principal == null)
            {
                Console.WriteLine("Недействительный токен.");
                return null;
            }

            var username = principal.Identity!.Name;

            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Username == username)!;
                return user;
            }
        }
    }
}
