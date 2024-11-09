

var manualResetEvent = new AsyncManualResetEvent(false); // Начальное состояние — несигнальное

// Запускаем задачи, ожидающие сигнала
var task1 = Task.Run(async () =>
{
    Console.WriteLine("Task 1 is waiting for the signal...");
    await manualResetEvent.WaitAsync();
    Console.WriteLine("Task 1 received the signal and is continuing.");
});

var task2 = Task.Run(async () =>
{
    Console.WriteLine("Task 2 is waiting for the signal...");
    await manualResetEvent.WaitAsync();
    Console.WriteLine("Task 2 received the signal and is continuing.");
});

await Task.Delay(1000);
Console.WriteLine("Main thread sets the signal.");
manualResetEvent.Set(); // Все ожидающие задачи получают сигнал и продолжают выполнение

await Task.Delay(1000);
Console.WriteLine("Main thread resets the signal.");
manualResetEvent.Reset(); // Сбрасываем событие

// Новая задача, которая будет ожидать сигнала
var task3 = Task.Run(async () =>
{
    Console.WriteLine("Task 3 is waiting for the signal...");
    await manualResetEvent.WaitAsync();
    Console.WriteLine("Task 3 received the signal and is continuing.");
});

await Task.Delay(1000);
Console.WriteLine("Main thread sets the signal again.");
manualResetEvent.Set(); // Теперь task3 продолжает выполнение

await Task.WhenAll(task1, task2, task3);

public class AsyncManualResetEvent
{
    private volatile TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

    public AsyncManualResetEvent(bool initialState = false)
    {
        if (initialState)
        {
            tcs.SetResult(true); // Инициализируем в сигнальном состоянии, если требуется
        }
    }

    public Task WaitAsync()
    {
        return tcs.Task; // Ожидание завершения задачи
    }

    public void Set()
    {
        // Устанавливаем событие в сигнальное состояние
        if (!tcs.Task.IsCompleted)
        {
            tcs.SetResult(true); // Завершаем задачу, позволяя всем ожидающим продолжить выполнение
        }
    }

    public void Reset()
    {
        // Сбрасываем событие в несигнальное состояние
        if (tcs.Task.IsCompleted)
        {
            tcs = new TaskCompletionSource<bool>(); // Создаем новую задачу, возвращая в несигнальное состояние
        }
    }
}
