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

Console.ReadLine();



class BankAccount
{
    private decimal balance;
    private ManualResetEvent manualResetEvent = new ManualResetEvent(true); // Начальное состояние — сигнальное

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        manualResetEvent.WaitOne(); // Блокируем доступ другим потокам
        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is depositing {amount}");
            balance += amount;
            Console.WriteLine($"New balance after deposit: {balance}");
        }
        finally
        {
            manualResetEvent.Set(); // Оставляем событие в сигнальном состоянии, чтобы другие потоки могли работать
        }
    }

    public void Withdraw(decimal amount)
    {
        manualResetEvent.WaitOne(); // Блокируем доступ другим потокам
        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is withdrawing {amount}");
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
            manualResetEvent.Set(); // Оставляем событие в сигнальном состоянии, чтобы другие потоки могли работать
        }
    }
}
