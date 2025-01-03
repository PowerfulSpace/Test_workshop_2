
int maxWeight = 5; // Максимальный вес рюкзака
int[] weights = { 3, 2 }; // Веса предметов
int[] values = { 6, 4 }; // Стоимости предметов

Console.WriteLine(FindMaximumValue(0, weights, values, maxWeight));

Console.ReadLine();



int FindMaximumValue(int index, int[] weights, int[] values, int remainingWeight)
{
    Console.WriteLine($"Index: {index}, RemainingWeight: {remainingWeight}");
    // Базовый случай: если индекс выходит за пределы списка
    if (index == weights.Length)
    {
        return 0;
    }

    // Если текущий предмет не вмещается, пропускаем его
    if (weights[index] > remainingWeight)
    {
        return FindMaximumValue(index + 1, weights, values, remainingWeight);
    }

    // Вариант 1: пропустить текущий предмет
    int skip = FindMaximumValue(index + 1, weights, values, remainingWeight);

    // Вариант 2: взять текущий предмет
    int take = values[index] + FindMaximumValue(index + 1, weights, values, remainingWeight - weights[index]);

    // Возвращаем максимум из двух вариантов
    return Math.Max(skip, take);
}