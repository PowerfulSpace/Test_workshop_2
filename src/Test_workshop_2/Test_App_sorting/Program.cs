
public class BankAccount
{
    public decimal Balance { get; protected set; }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Сумма должна быть положительной.");
        }
        Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Сумма должна быть положительной.");
        }
        if (amount > Balance)
        {
            throw new InvalidOperationException("Недостаточно средств.");
        }
        Balance -= amount;
    }
}


public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; set; }

    public void AddInterest()
    {
        Balance += Balance * InterestRate;
    }
}


public class CheckingAccount : BankAccount
{
    public override void Withdraw(decimal amount)
    {
        // Разрешаем овердрафт
        if (amount <= 0)
        {
            throw new ArgumentException("Сумма должна быть положительной.");
        }
        if (amount > Balance)
        {
            throw new InvalidOperationException("Недостаточно средств.");
        }
        Balance -= amount;
    }
}