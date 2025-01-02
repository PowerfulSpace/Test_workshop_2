
int maxWeight = 15; // Максимальный вес рюкзака
int[] weights = { 1, 3, 4, 5, 6, 7 }; // Веса предметов
int[] values = { 1, 4, 5, 7, 10, 13 }; // Стоимости предметов

Console.WriteLine(FindMaximumValue(0, weights, values, 0));

Console.ReadLine();



int FindMaximumValue(int index, int[] weights, int[] values, int remainingWeight)
{
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