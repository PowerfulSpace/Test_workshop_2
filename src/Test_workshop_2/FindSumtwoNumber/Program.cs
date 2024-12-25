
int[] array = { 10, 6, 35, 8, 16, 17, 14, 48, 29, 40, 21, 42, 47, 4, 38 };

int s = 50;

var result = FindSumtwoNumber(array, s);

Console.WriteLine(result.Item1 + " " + result.Item2);

Console.ReadLine();


(int, int) FindSumtwoNumber(int[] array, int s)
{
    HashSet<int> seen = new HashSet<int>();

    foreach (int num in array)
    {
        int complement = s - num;
        if (seen.Contains(complement))
        {
            return (complement, num);
        }
        seen.Add(num);
    }

    throw new Exception($"Нет пар, которые в сумме образуют {s}");
}
