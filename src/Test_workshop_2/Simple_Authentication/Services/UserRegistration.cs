using Simple_Authentication.Data;
using Simple_Authentication.Models;

namespace Simple_Authentication.Services
{
    public static class UserRegistration
    {
        public static void Register(ApplicationContext dbContext)
        {
            Console.WriteLine("Регистрация пользователя:");
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine()!;

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine()!;

            string passwordHash = PasswordHasher.HashPassword(password);

            User newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = passwordHash
            };

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            Console.WriteLine("Пользователь успешно зарегистрирован!");
        }
    }
}
