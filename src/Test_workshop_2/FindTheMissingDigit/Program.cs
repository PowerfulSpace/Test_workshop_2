
int[] numbers = { 1, 2, 3, 4, 5, 7, 8, 9, 10 };

Console.WriteLine(FindTheMissingDigit(numbers));

Console.ReadLine();



int FindTheMissingDigit(int[] array)
{
    if (array == null || array.Length == 0)
        throw new ArgumentException("Массив не должен быть пустым");

    int result = 0;

    for (int i = 0; i < array.Length - 1; i++)
    {
        if (array[i] + 1 != array[i + 1])
        {
            return array[i] + 1;
        }
    }

    return result;
}