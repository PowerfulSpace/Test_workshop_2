using Easy_Url_Shortener_App.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Easy_Url_Shortener_App.Services
{
    public class UrlShortenerService
    {
        private readonly IDatabase _db;

        public UrlShortenerService(IDatabase db)
        {
            _db = db;
        }

        // Генерация случайного короткого кода (например, 6 символов)
        public string GenerateShortCode()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var shortCode = new char[6];
            for (int i = 0; i < shortCode.Length; i++)
            {
                shortCode[i] = chars[random.Next(chars.Length)];
            }
            return new string(shortCode);
        }

        // Сокращение ссылки
        public string ShortenUrl(string longUrl)
        {
            // Генерируем короткий код
            var shortCode = GenerateShortCode();

            // Проверяем, что такой код уже не существует
            while (_db.KeyExists(shortCode))
            {
                shortCode = GenerateShortCode();
            }

            // Сохраняем короткую и длинную ссылки в Redis
            var shortUrl = new ShortUrl { LongUrl = longUrl, ShortCode = shortCode };
            _db.StringSet(shortCode, JsonConvert.SerializeObject(shortUrl));

            return shortCode;
        }

        // Получение длинной ссылки по короткому коду
        public string GetLongUrl(string shortCode)
        {
            var value = _db.StringGet(shortCode);
            if (string.IsNullOrEmpty(value))
            {
                return null; // Короткая ссылка не найдена
            }

            var shortUrl = JsonConvert.DeserializeObject<ShortUrl>(value);
            return shortUrl.LongUrl;
        }
    }
}
