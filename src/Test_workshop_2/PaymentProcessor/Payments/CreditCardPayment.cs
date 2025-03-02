using PaymentProcessor.Interfaces;

namespace PaymentProcessor.Payments
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(IPaymentProcessor paymentProcessor) : base(paymentProcessor)
        {
        }

        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Making credit card payment...");
            base.MakePayment(amount);
        }
    }
}
