namespace PaymentProcessor.Interfaces
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }
}
