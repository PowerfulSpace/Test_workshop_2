
using Cache_Average_MemoryCache.Models;
using Cache_Average_MemoryCache.Services;
using System.Runtime.Caching;

MemoryCache cache = MemoryCache.Default;
string cacheKey = "user_123";
User user;
UserService userService = new UserService(); // Экземпляр сервиса

if (cache.Contains(cacheKey))
{
    user = cache.Get(cacheKey) as User;
    Console.WriteLine($"Пользователь получен из кэша: {user.Name}, {user.Email}");
}
else
{
    // Используем UserService для получения данных пользователя
    user = userService.GetUserById(123);

    CacheItemPolicy policy = new CacheItemPolicy
    {
        AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1)
    };
    cache.Add(cacheKey, user, policy);

    Console.WriteLine($"Пользователь загружен из базы данных: {user.Name}, {user.Email}");
}


Console.ReadLine();