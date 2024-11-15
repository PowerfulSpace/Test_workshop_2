
CountdownEvent countdown = new CountdownEvent(10);

for (int i = 0; i < 10; i++)
{
    Task.Run(() => DoWork(i));
}

// Главный поток ожидает завершения 10 операций
Console.WriteLine("Главный поток ждет завершения 10 операций.");
countdown.Wait();
Console.WriteLine("10 операций выполнены. Главный поток продолжает работу.");


Console.ReadLine();

