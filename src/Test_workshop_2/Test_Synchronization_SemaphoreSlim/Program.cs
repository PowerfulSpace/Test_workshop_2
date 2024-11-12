

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



}
