
int maxWeight = 15; // Максимальный вес рюкзака
int[] weights = { 1, 3, 4, 5, 6, 7 }; // Веса предметов
int[] values = { 1, 4, 5, 7, 10, 13 }; // Стоимости предметов

Console.WriteLine(FindMaximumValueOfItems(0, weights, values, 0, maxWeight, 0, 0));

Console.ReadLine();


int FindMaximumValueOfItems(int index, int[] weights, int[] values, int currentWeight, int maxWeight, int currentPrice, int maxPrice)
{
    if (currentWeight > maxWeight)
    {
        return maxPrice;
    }
    if (currentPrice > maxPrice)
    {
        maxPrice = currentPrice;
    }

    for (int i = index; i < weights.Length; i++)
    {
        currentPrice += values[i];
        currentWeight += weights[i];

        maxPrice = FindMaximumValueOfItems(i + 1, weights, values, currentWeight, maxWeight, currentPrice, maxPrice);

        currentPrice -= values[i];
        currentWeight -= weights[i];
    }


    return maxPrice;
}