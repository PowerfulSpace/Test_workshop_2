// Настройка логирования через Serilog с отправкой данных в Elasticsearch
using Serilog;
using Serilog.Sinks.Elasticsearch;



// Настройка Serilog для отправки данных в Elasticsearch
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()  // Логи выводятся в консоль
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
    {
        AutoRegisterTemplate = true,             // Авто-регистрация шаблона индекса
        IndexFormat = "applogs-{0:yyyy.MM.dd}",  // Формат индекса для логов
        NumberOfShards = 1,                      // Количество шардов
        NumberOfReplicas = 0                     // Количество реплик
    })
    .CreateLogger();

// Пример различных логов
Log.Information("Приложение запущено.");
Log.Warning("Это тестовое предупреждение.");
Log.Error("Это тестовая ошибка.");

// Завершение работы логирования
Log.CloseAndFlush();

Console.ReadLine();