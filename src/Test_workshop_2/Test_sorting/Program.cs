

using System.Numerics;

double num = 50;

double result = FindNumFibonachi(num);

Console.WriteLine(result);

Console.ReadLine();

double FindNumFibonachi(double num)
{
    double first = 0;
    double second = 1;

    for (double i = 2; i <= num; i++)
    {
        double temp = second;
        second = first + second;
        first = temp;
    }

    return second;
}


BigInteger FindFibonacci(int n)
{
    // Для первых двух чисел Фибоначчи
    if (n == 0) return 0;
    if (n == 1) return 1;

    // Динамическое программирование
    BigInteger[] fib = new BigInteger[n + 1];
    fib[0] = 0;
    fib[1] = 1;

    for (int i = 2; i <= n; i++)
    {
        fib[i] = fib[i - 1] + fib[i - 2];
    }

    return fib[n];
}