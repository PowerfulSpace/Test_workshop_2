
CountdownEvent countdown = new CountdownEvent(10);

for (int i = 0; i < 100; i++)
{
    Task.Run(() => DoWork(i));
}

// Главный поток ожидает завершения 10 операций
Console.WriteLine("Главный поток ждет завершения 10 операций.");
countdown.Wait();
Console.WriteLine("10 операций выполнены. Главный поток продолжает работу.");


Console.ReadLine();

void DoWork(int id)
{
    Console.WriteLine($"Поток {id} начинает работу.");
    Thread.Sleep(new Random().Next(500, 2000)); // Симуляция работы
    Console.WriteLine($"Поток {id} завершил работу.");

    // Сигнализируем о завершении работы
    countdown.Signal();
}