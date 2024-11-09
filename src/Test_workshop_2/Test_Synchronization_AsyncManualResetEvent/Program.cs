
Printer printer = new Printer();

// Создаём задачи печати
var printTasks = new[]
{
            printer.PrintDocumentAsync("Document1"),
            printer.PrintDocumentAsync("Document2")
        };

Console.WriteLine("Waiting for user permission to print...");
// Симулируем задержку перед получением разрешения на печать
await Task.Delay(3000);
printer.AllowPrinting(); // Разрешаем печать

await Task.WhenAll(printTasks); // Ожидаем завершения всех задач печати

// Сбрасываем печать для новых задач
printer.ResetPrinting();
Console.WriteLine("Ready for new print jobs.");




public class AsyncManualResetEvent
{
    private TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

    public Task WaitAsync() => tcs.Task;

    public void Set() => tcs.TrySetResult(true);

    public void Reset()
    {
        if (tcs.Task.IsCompleted)
        {
            tcs = new TaskCompletionSource<bool>();
        }
    }
}


public class Printer
{
    private readonly AsyncManualResetEvent printEvent = new AsyncManualResetEvent();

    public async Task PrintDocumentAsync(string document)
    {
        Console.WriteLine($"Preparing to print document: {document}");
        await printEvent.WaitAsync(); // Ждём разрешения на печать
        Console.WriteLine($"Printing document: {document}");
        // Симуляция времени печати
        await Task.Delay(2000);
        Console.WriteLine($"Document {document} printed successfully.");
    }

    public void AllowPrinting()
    {
        printEvent.Set(); // Разрешаем печать
    }

    public void ResetPrinting()
    {
        printEvent.Reset(); // Сброс разрешения на печать для новых задач
    }
}

