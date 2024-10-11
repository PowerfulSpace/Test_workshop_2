using System.Collections.Concurrent;

Console.WriteLine("Start working with ConcurrentBag!");

ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();

Task[] tasks = new Task[3];

// Два потока для добавления элементов
tasks[0] = Task.Run(() => AddItems());
tasks[1] = Task.Run(() => AddItems());

// Один поток для извлечения элементов
tasks[2] = Task.Run(() => ProcessItems());

Task.WaitAll(tasks);

Console.WriteLine("All tasks completed!");

// Метод для добавления элементов в ConcurrentBag
void AddItems()
{
    for (int i = 0; i < 5; i++)
    {
        concurrentBag.Add(i);
        Console.WriteLine($"Added: {i}");
        Thread.Sleep(100); // Задержка для демонстрации многопоточности
    }
}

// Метод для обработки элементов из ConcurrentBag
void ProcessItems()
{
    int item;
    while (!concurrentBag.IsEmpty)
    {
        if (concurrentBag.TryTake(out item))
        {
            Console.WriteLine($"Processed: {item}");
        }
        Thread.Sleep(150); // Задержка для демонстрации многопоточности
    }
}

Console.ReadLine();