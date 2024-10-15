using Cache_Redis.Models;
using Cache_Redis.Services;
using Newtonsoft.Json;
using StackExchange.Redis;

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");


string cacheKey = "user_123"; // Ключ для хранения данных конкретного пользователя
User user;
UserService userService = new UserService(); // Экземпляр сервиса


// Получаем доступ к базе данных Redis
IDatabase db = redis.GetDatabase();

// Пытаемся получить данные пользователя из кэша
string cachedUser = db.StringGet(cacheKey)!;
if (!string.IsNullOrEmpty(cachedUser))
{
    // Данные пользователя найдены в кэше
    user = JsonConvert.DeserializeObject<User>(cachedUser)!;
    Console.WriteLine($"Пользователь получен из Redis: {user.Name}, {user.Email}");
}
else
{
    // Данных в кэше нет, загружаем их из базы данных
    user = userService.GetUserById(123);

    // Сериализуем объект пользователя в строку и сохраняем его в Redis на 3 минуты
    db.StringSet(cacheKey, JsonConvert.SerializeObject(user), TimeSpan.FromMinutes(3));

    Console.WriteLine($"Пользователь загружен из базы данных и сохранён в Redis: {user.Name}, {user.Email}");
}

// Имитация повторного запроса
Console.WriteLine("\nИмитируем повторный запрос...");
Thread.Sleep(3000); // Подождем 3 секунды

// Снова пытаемся получить пользователя из Redis
cachedUser = db.StringGet(cacheKey)!;
if (!string.IsNullOrEmpty(cachedUser))
{
    user = JsonConvert.DeserializeObject<User>(cachedUser)!;
    Console.WriteLine($"Повторно получен пользователь из Redis: {user.Name}, {user.Email}");
}
else
{
    Console.WriteLine("Данные пользователя больше не находятся в Redis.");
}

Console.ReadLine();