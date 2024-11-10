

var account = new BankAccount(1000);

// Запуск асинхронных задач для депозита и снятия средств
var t1 = Task.Run(async () =>
{
    for (int i = 0; i < 3; i++)
        await account.Deposit(200);
});

var t2 = Task.Run(async () =>
{
    for (int i = 0; i < 3; i++)
        await account.Withdraw(150);
});

// Ожидание завершения всех задач
await Task.WhenAll(t1, t2);
Console.ReadLine();



class BankAccount
{
    private decimal balance;
    private AsyncManualResetEvent asyncManualResetEvent = new AsyncManualResetEvent(false); // Инициализируем как несигнальное

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public async Task Deposit(decimal amount)
    {
        await asyncManualResetEvent.WaitAsync(); // Ожидаем сигнала, чтобы начать операцию
        try
        {
            Console.WriteLine($"{Task.CurrentId} is depositing {amount}");
            await Task.Delay(500); // Симуляция работы
            balance += amount;
            Console.WriteLine($"New balance after deposit: {balance}");
        }
        finally
        {
            asyncManualResetEvent.Set(); // Позволяем другим задачам работать
        }
    }

    public async Task Withdraw(decimal amount)
    {
        await asyncManualResetEvent.WaitAsync(); // Ожидаем сигнала, чтобы начать операцию
        try
        {
            Console.WriteLine($"{Task.CurrentId} is withdrawing {amount}");
            await Task.Delay(500); // Симуляция работы
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"New balance after withdrawal: {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal");
            }
        }
        finally
        {
            asyncManualResetEvent.Set(); // Позволяем другим задачам работать
        }
    }
}

// Асинхронный аналог ManualResetEvent
public class AsyncManualResetEvent
{
    private TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

    public AsyncManualResetEvent(bool initialState)
    {
        if (initialState)
        {
            tcs.SetResult(true); // Сигнальное состояние
        }
    }

    public Task WaitAsync()
    {
        var t = tcs.Task;
        if (t.IsCompleted)
        {
            tcs = new TaskCompletionSource<bool>(); // Сбрасываем на несигнальное состояние
        }
        return t;
    }

    public void Set()
    {
        if (!tcs.Task.IsCompleted)
        {
            tcs.SetResult(true); // Устанавливаем в сигнальное состояние
        }
    }
}
