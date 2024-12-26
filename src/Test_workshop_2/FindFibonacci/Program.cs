

using System.Numerics;

long num = 50;

long result = FindNumFibonachi(num);

Console.WriteLine(result);

Console.ReadLine();

long FindNumFibonachi(long num)
{
    long first = 0;
    long second = 1;

    for (long i = 2; i <= num; i++)
    {
        long temp = second;
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