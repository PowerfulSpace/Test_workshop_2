



var dataService = new DataService();

// Первый вызов: данные загружаются из БД
var data1 = await dataService.GetDataAsync(1);
Console.WriteLine(data1);

// Второй вызов: данные берутся из кэша
var data2 = await dataService.GetDataAsync(1);
Console.WriteLine(data2);



Console.ReadLine();




public class DataService
{
    // Кэш для хранения данных
    private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();

    // Метод для получения данных
    public async ValueTask<string> GetDataAsync(int id)
    {
        // Проверяем, есть ли данные в кэше
        if (_cache.TryGetValue(id, out var data))
        {
            Console.WriteLine("Данные найдены в кэше.");
            return data; // Синхронный возврат
        }

        // Если данных нет в кэше, загружаем их из базы данных
        Console.WriteLine("Данные не найдены в кэше. Загрузка из БД...");
        data = await FetchDataFromDbAsync(id);

        // Сохраняем данные в кэше
        _cache[id] = data;
        return data;
    }

    // Метод для имитации загрузки данных из БД
    private async Task<string> FetchDataFromDbAsync(int id)
    {
        await Task.Delay(1000); // Имитация задержки
        return $"Данные для ID {id}";
    }
}