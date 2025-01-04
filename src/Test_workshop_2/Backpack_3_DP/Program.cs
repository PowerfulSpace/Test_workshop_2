
//int maxWeight = 15; // Максимальный вес рюкзака
//int[] weights = { 1, 3, 4, 5, 6, 7 }; // Веса предметов
//int[] values = { 1, 4, 5, 7, 10, 13 }; // Стоимости предметов

int maxWeight = 7; // Максимальный вес рюкзака
int[] weights = { 2, 3, 4 }; // Веса предметов
int[] values = { 3, 4, 5 }; // Стоимости предметов

Console.WriteLine(FindMaximumValueDP(weights, values, maxWeight));

Console.ReadLine();



int FindMaximumValueDP(int[] weights, int[] values, int maxWeight)
{
    int n = weights.Length;
    int[,] dp = new int[n + 1, maxWeight + 1];

    // Заполняем таблицу dp
    for (int i = 1; i <= n; i++)
    {
        Console.WriteLine();
        for (int w = 1; w <= maxWeight; w++)
        {
            if (weights[i - 1] <= w) // Если текущий предмет помещается в рюкзак
            {
                int notTake = dp[i - 1, w];
                int price = values[i - 1];
                int excessWeight = w - weights[i - 1];
                int excessPrice = dp[i - 1, excessWeight];

                dp[i, w] = Math.Max(
                    dp[i - 1, w], // Не брать текущий предмет
                    values[i - 1] + dp[i - 1, w - weights[i - 1]] // Взять текущий предмет
                );
            }
            else
            {
                dp[i, w] = dp[i - 1, w]; // Если предмет не помещается
            }
        }
    }

    // Максимальная стоимость будет в dp[n, maxWeight]
    return dp[n, maxWeight];
}