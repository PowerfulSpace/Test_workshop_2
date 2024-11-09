
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
class BankAccount
{
    private decimal balance;
    private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // Разрешаем только одному потоку выполнять операции

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public async Task DepositAsync(decimal amount)
    {
        await semaphore.WaitAsync(); // Захватываем семафор асинхронно
        try
        {
            Console.WriteLine($"{Task.CurrentId} is depositing {amount}");
            balance += amount;
            Console.WriteLine($"New balance after deposit: {balance}");
        }
        finally
        {
            semaphore.Release(); // Освобождаем семафор
        }
    }

    public async Task WithdrawAsync(decimal amount)
    {
        await semaphore.WaitAsync(); // Захватываем семафор асинхронно
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
            semaphore.Release(); // Освобождаем семафор
        }
    }
}

