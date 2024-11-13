

Barrier barrier = new Barrier(4, (b) =>
{
    // Эта часть кода выполняется после того, как все потоки достигли барьера
    Console.WriteLine("Все потоки достигли барьера на фазе " + b.CurrentPhaseNumber);
});


for (int i = 0; i < 4; i++)
{
    Thread t = new Thread(DoWork) { Name = $"Thread {i + 1}" };
    t.Start();
}

Console.ReadLine();


void DoWork()
{
    for (int i = 0; i < 3; i++) // 3 фазы работы
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} выполняет работу на фазе {i}");
        Thread.Sleep(new Random().Next(1000, 3000)); // Симуляция работы

        // Поток достигает барьера и ждет других
        Console.WriteLine($"{Thread.CurrentThread.Name} достиг барьера на фазе {i}");
        barrier.SignalAndWait();
    }
}

