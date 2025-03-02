using PaymentProcessor.Interfaces;

namespace PaymentProcessor.Payments
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(IPaymentProcessor paymentProcessor) : base(paymentProcessor)
        {
        }

        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Making PayPal payment...");
            base.MakePayment(amount);
        }
    }
}
