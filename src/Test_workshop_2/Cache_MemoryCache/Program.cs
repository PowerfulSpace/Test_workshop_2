using System.Runtime.Caching;

// Создаём экземпляр MemoryCache
MemoryCache cache = MemoryCache.Default;

string cacheKey = "myData";
string cachedData;

// Проверяем, есть ли данные в кэше
if (cache.Contains(cacheKey))
{
    // Если данные уже есть в кэше, получаем их
    cachedData = cache.Get(cacheKey) as string;
    Console.WriteLine("Данные получены из кэша: " + cachedData);
}
else
{
    // Если данных нет в кэше, выполняем какую-то длительную операцию
    cachedData = GetDataFromSlowSource();

    // Добавляем результат операции в кэш на 10 секунд
    CacheItemPolicy policy = new CacheItemPolicy
    {
        AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10)
    };
    cache.Add(cacheKey, cachedData, policy);

    Console.WriteLine("Данные загружены и сохранены в кэш: " + cachedData);
}

Console.WriteLine("Ожидание 12 секунд...");
Thread.Sleep(12000);

// Проверяем снова, есть ли данные в кэше после ожидания
if (cache.Contains(cacheKey))
{
    cachedData = cache.Get(cacheKey) as string;
    Console.WriteLine("Данные все еще в кэше: " + cachedData);
}
else
{
    Console.WriteLine("Данные были удалены из кэша.");
}

string GetDataFromSlowSource()
{
    // Симулируем получение данных из медленного источника
    Thread.Sleep(2000); // Имитируем задержку в 2 секунды
    return "Это данные из медленного источника";
}

Console.ReadLine();