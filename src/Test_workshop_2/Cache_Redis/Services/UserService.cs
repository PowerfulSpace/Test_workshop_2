using Cache_Redis.Models;

namespace Cache_Redis.Services
{
    public class UserService
    {
        // Метод для получения пользователя из базы данных по ID
        public User GetUserById(int userId)
        {
            Console.WriteLine("Имитируем запрос к базе данных...");
            // В реальном приложении здесь был бы запрос к базе данных
            Thread.Sleep(2000); // Имитация задержки на 2 секунды

            return new User
            {
                Id = userId,
                Name = "Иван Иванов",
                Email = "ivan.ivanov@example.com"
            };
        }
    }
}
