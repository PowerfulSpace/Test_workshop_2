

var account = new BankAccount(1000);

Thread t1 = new Thread(() => {
    for (int i = 0; i < 3; i++)
        account.Deposit(200);
})
{ Name = "Thread 1" };

Thread t2 = new Thread(() => {
    for (int i = 0; i < 3; i++)
        account.Withdraw(150);
})
{ Name = "Thread 2" };

t1.Start();
t2.Start();

t1.Join();
t2.Join();

class BankAccount
{
    private decimal balance;
    private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // Разрешаем только одному потоку выполнять операции

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        semaphore.Wait(); // Захватываем семафор синхронно
        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is depositing {amount}");
            balance += amount;
            Console.WriteLine($"New balance after deposit: {balance}");
        }
        finally
        {
            semaphore.Release(); // Обязательно освобождаем семафор
        }
    }


}
