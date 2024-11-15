
int counter = 0;

Thread[] threads = new Thread[10];

for (int i = 0; i < 5; i++)
{
    threads[i] = new Thread(Increment);
    threads[i + 5] = new Thread(Decrement);
}

foreach (Thread t in threads)
{
    t.Start();
}

foreach (Thread t in threads)
{
    t.Join();
}

Console.WriteLine($"Итоговое значение счетчика: {counter}");

Console.ReadLine();


void Increment()
{
    for (int i = 0; i < 20; i++)
    {
        Interlocked.Increment(ref counter);
        Console.WriteLine(counter);
    }
}

void Decrement()
{
    for (int i = 0; i < 20; i++)
    {
        Interlocked.Decrement(ref counter);
        Console.WriteLine(counter);
    }
}