


var account = new BankAccount(1000);

Thread t1 = new Thread(() =>
{
    for (int i = 0; i < 3; i++)
        account.Deposit(200);
})
{ Name = "Thread 1" };

Thread t2 = new Thread(() =>
{
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
    private Mutex mutex = new Mutex();

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        mutex.WaitOne();  // Захватываем мьютекс, блокируя другие потоки
        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is depositing {amount}");
            balance += amount;
            Console.WriteLine($"New balance after deposit: {balance}");
        }
        finally
        {
            mutex.ReleaseMutex();  // Обязательно освобождаем мьютекс
        }
    }

    public void Withdraw(decimal amount)
    {
        mutex.WaitOne();  // Захватываем мьютекс
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
            mutex.ReleaseMutex();  // Обязательно освобождаем мьютекс
        }
    }
}


