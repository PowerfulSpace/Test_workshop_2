using PaymentProcessor.Interfaces;

namespace PaymentProcessor.PaymentProcessors
{
    public class CryptocurrencyPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing cryptocurrency payment of {amount:C}");
        }
    }

}