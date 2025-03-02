using PaymentProcessor.Interfaces;

namespace PaymentProcessor.Payments
{
    public class CryptocurrencyPayment : Payment
    {
        public CryptocurrencyPayment(IPaymentProcessor paymentProcessor) : base(paymentProcessor)
        {
        }

        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Making cryptocurrency payment...");
            base.MakePayment(amount);
        }
    }
}
