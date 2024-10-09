using Average_Authentication.Data;
using Average_Authentication.Helpers;
using Average_Authentication.Models;

namespace Average_Authentication.Services
{
    public class AuthService
    {
        public static void Register(string username, string password, string role = "User")
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Проверяем, существует ли пользователь с таким именем
                if (db.Users.Any(u => u.Username == username))
                {
                    Console.WriteLine("Пользователь с таким именем уже существует.");
                    return;
                }

                // Генерация соли и хэширование пароля
                string salt = PasswordHelper.GenerateSalt();
                string passwordHash = PasswordHelper.HashPassword(password, salt);

                // Создаем нового пользователя
                User newUser = new User
                {
                    Id = Guid.NewGuid(),
                    Username = username,
                    PasswordHash = passwordHash,
                    Salt = salt,
                    Role = role // Присваиваем роль при регистрации
                };

                db.Users.Add(newUser);
                db.SaveChanges();
                Console.WriteLine($"Пользователь {username} с ролью {role} успешно зарегистрирован.");
            }
        }

        public static User? Authenticate(string username, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Ищем пользователя по имени
                User user = db.Users.FirstOrDefault(u => u.Username == username)!;

                if (user == null)
                {
                    Console.WriteLine("Пользователь не найден.");
                    return null;
                }

                // Проверяем правильность пароля
                if (!PasswordHelper.VerifyPassword(password, user.PasswordHash, user.Salt))
                {
                    Console.WriteLine("Неверный пароль.");
                    return null;
                }

                Console.WriteLine($"Успешная аутентификация. Роль: {user.Role}");
                return user;
            }
        }
    }
}
