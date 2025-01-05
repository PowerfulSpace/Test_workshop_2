
int[][] arrays = new int[][]
{
    new int[] { 3, 6, 9, 12, 15 }, // Арифметическая прогрессия (d = 3)
    new int[] { 2, 4, 8, 16, 32 }, // Геометрическая прогрессия (r = 2)
    new int[] { 5, 10, 15, 20, 25 }, // Арифметическая прогрессия (d = 5)
    new int[] { 81, 27, 9, 3, 1 }, // Геометрическая прогрессия (r = 1/3)
    new int[] { 1, 2, 4, 7, 11 }  // Не является прогрессией
};


foreach (int[] array in arrays)
{
    Console.WriteLine("Последовательность является : {0} прогрессией", FindProgression(array));
}



Console.ReadLine();


string FindProgression(int[] array)
{
    if (array.Length < 2) return "Недостаточно данных";

    bool isArithmetic = true;
    bool isGeometric = true;

    int arithmeticDifference = array[1] - array[0];
    double geometricRatio = (double)array[1] / array[0];

    for (int i = 2; i < array.Length; i++)
    {
        if (array[i] - array[i - 1] != arithmeticDifference)
        {
            isArithmetic = false;
        }
        if (Math.Abs((double)array[i] / array[i - 1] - geometricRatio) > 1e-9)
        {
            isGeometric = false;
        }
    }

    if (isArithmetic) return "арифметической";
    if (isGeometric) return "геометрической";
    return "не является прогрессией";
}
