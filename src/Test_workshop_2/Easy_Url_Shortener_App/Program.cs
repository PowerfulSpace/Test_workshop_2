// Подключаемся к Redis
using Easy_Url_Shortener_App.Services;
using StackExchange.Redis;

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
IDatabase db = redis.GetDatabase();

// Создаем сервис для работы с ссылками
var urlService = new UrlShortenerService(db);

// Пример использования: сокращаем ссылку
Console.WriteLine("Введите длинную ссылку:");
string longUrl = Console.ReadLine();
string shortCode = urlService.ShortenUrl(longUrl);

Console.WriteLine($"Сокращенная ссылка: http://short.url/{shortCode}");

// Имитация получения длинной ссылки по короткой
Console.WriteLine("\nВведите короткую ссылку для восстановления:");
string inputShortCode = Console.ReadLine();
string originalUrl = urlService.GetLongUrl(inputShortCode);

if (originalUrl != null)
{
    Console.WriteLine($"Исходная длинная ссылка: {originalUrl}");
}
else
{
    Console.WriteLine("Короткая ссылка не найдена!");
}

Console.ReadLine();