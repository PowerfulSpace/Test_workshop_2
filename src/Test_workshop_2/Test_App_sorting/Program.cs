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


}

