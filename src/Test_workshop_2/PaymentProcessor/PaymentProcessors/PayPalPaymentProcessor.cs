using PaymentProcessor.Interfaces;

namespace PaymentProcessor.PaymentProcessors
{
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
        }
    }
}
