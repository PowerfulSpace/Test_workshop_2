using PaymentProcessor.Interfaces;

namespace PaymentProcessor
{
    public class Payment
    {
        protected IPaymentProcessor paymentProcessor;

        public Payment(IPaymentProcessor paymentProcessor)
        {
            this.paymentProcessor = paymentProcessor;
        }

        public virtual void MakePayment(decimal amount)
        {
            paymentProcessor.ProcessPayment(amount);
        }
    }
}
