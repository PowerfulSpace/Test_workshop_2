
using PaymentProcessor.Interfaces;
using PaymentProcessor.PaymentProcessors;
using PaymentProcessor.Payments;
using PaymentProcessor;

IPaymentProcessor creditCardProcessor = new CreditCardPaymentProcessor();
Payment creditCardPayment = new CreditCardPayment(creditCardProcessor);
creditCardPayment.MakePayment(100.0m);

IPaymentProcessor payPalProcessor = new PayPalPaymentProcessor();
Payment payPalPayment = new PayPalPayment(payPalProcessor);
payPalPayment.MakePayment(150.0m);

IPaymentProcessor cryptoProcessor = new CryptocurrencyPaymentProcessor();
Payment cryptoPayment = new CryptocurrencyPayment(cryptoProcessor);
cryptoPayment.MakePayment(200.0m);


Console.ReadLine();