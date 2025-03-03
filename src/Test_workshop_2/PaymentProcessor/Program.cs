
using PaymentProcessor.Interfaces;
using PaymentProcessor.PaymentProcessors;
using PaymentProcessor.Payments;
using PaymentProcessor;

IPaymentProcessor creditCardProcessor = new CreditCardPaymentProcessor();
Payment creditCardPayment = new CreditCardPayment(creditCardProcessor);
creditCardPayment.MakePayment(100.0m);




Console.ReadLine();