


var account = new BankAccount(1000);

Task t1 = Task.Run(async () => {
    for (int i = 0; i < 3; i++)
        await account.DepositAsync(200);
});

Task t2 = Task.Run(async () => {
    for (int i = 0; i < 3; i++)
        await account.WithdrawAsync(150);
});

await Task.WhenAll(t1, t2); // Ожидаем завершения обеих задач

Console.ReadLine();


class BankAccount
{
    private decimal balance;
    private AsyncAutoResetEvent autoResetEvent = new AsyncAutoResetEvent(true); // Инициализируем в сигнальном состоянии

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public async Task DepositAsync(decimal amount)
    {
        await autoResetEvent.WaitAsync(); // Ожидаем сигнала асинхронно
        try
        {
            Console.WriteLine($"{Task.CurrentId} is depositing {amount}");
            balance += amount;
            Console.WriteLine($"New balance after deposit: {balance}");
        }
        finally
        {
            autoResetEvent.Set(); // Устанавливаем событие в сигнальное состояние
        }
    }

    public async Task WithdrawAsync(decimal amount)
    {
        await autoResetEvent.WaitAsync(); // Ожидаем сигнала асинхронно
        try
        {
            Console.WriteLine($"{Task.CurrentId} is withdrawing {amount}");
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
            autoResetEvent.Set(); // Устанавливаем событие в сигнальное состояние
        }
    }
}




public class AsyncAutoResetEvent
{
    private readonly static Task Completed = Task.FromResult(true);
    private TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

    public AsyncAutoResetEvent(bool initialState)
    {
        if (initialState)
        {
            tcs.SetResult(true); // Инициализируем как сигнальное
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
        // Устанавливаем событие в сигнальное состояние
        if (!tcs.Task.IsCompleted)
        {
            tcs.SetResult(true);
        }
    }
}
