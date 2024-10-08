using Simple_Authentication.Data;

namespace Simple_Authentication.Services
{
    public static class UserAuthentication
    {
        public static void Authenticate(ApplicationContext dbContext)
        {
            Console.WriteLine("Вход пользователя:");
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine()!;

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine()!;

            var user = dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && PasswordHasher.VerifyPassword(password, user.PasswordHash))
            {
                Console.WriteLine("Аутентификация прошла успешно! Добро пожаловать.");
            }
            else
            {
                Console.WriteLine("Неверное имя пользователя или пароль.");
            }
        }
    }
}
