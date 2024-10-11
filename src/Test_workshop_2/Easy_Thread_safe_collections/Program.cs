// Определяем конкурентные коллекции
using System.Collections.Concurrent;

ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();
ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();



Console.WriteLine("Start working with concurrent collections!");

// Создаем и запускаем задачи для работы с очередью и словарем
Task[] tasks = new Task[4];

// Два потока для добавления элементов в очередь
tasks[0] = Task.Run(() => EnqueueItems());
tasks[1] = Task.Run(() => EnqueueItems());

// Один поток для обработки элементов из очереди
tasks[2] = Task.Run(() => DequeueItems());

// Один поток для работы с ConcurrentDictionary
tasks[3] = Task.Run(() => WorkWithDictionary());

// Ждем завершения всех задач
Task.WaitAll(tasks);

// Выводим итоговое состояние словаря
Console.WriteLine("\nFinal content of ConcurrentDictionary:");
foreach (var item in concurrentDictionary)
{
    Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
}

Console.WriteLine("All tasks completed!");


Console.ReadLine();


// Метод добавления элементов в очередь
void EnqueueItems()
{
    for (int i = 0; i < 10; i++)
    {
        concurrentQueue.Enqueue(i);
        Console.WriteLine($"Enqueued: {i}");
        Thread.Sleep(100); // Искусственная задержка для демонстрации многопоточности
    }
}

// Метод извлечения элементов из очереди
void DequeueItems()
{
    int item;
    while (true)
    {
        if (concurrentQueue.TryDequeue(out item))
        {
            Console.WriteLine($"Dequeued: {item}");
            concurrentDictionary.TryAdd(item, $"Processed-{item}");
        }
        else
        {
            if (concurrentQueue.IsEmpty)
            {
                break; // Если очередь пуста, выходим из цикла
            }
        }
        Thread.Sleep(150); // Искусственная задержка для демонстрации многопоточности
    }
}

// Метод работы с ConcurrentDictionary
void WorkWithDictionary()
{
    for (int i = 100; i < 110; i++)
    {
        concurrentDictionary.TryAdd(i, $"Initial-{i}");
        Console.WriteLine($"Added to dictionary: Key={i}, Value=Initial-{i}");
        Thread.Sleep(200); // Искусственная задержка для демонстрации многопоточности
    }
}