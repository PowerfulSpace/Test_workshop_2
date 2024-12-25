
int[] array = { 10, 6, 35, 8, 16, 17, 14, 48, 29, 40, 21, 42, 47, 4, 38 };

int s = 50;

var result = FindSumtwoNumber(array, s);

Console.WriteLine(result.Item1 + " " + result.Item2);

Console.ReadLine();


(int,int) FindSumtwoNumber(int[] array, int s)
{
    int first = 0;
    int second = 0;
    int remainder = 0;

    for (int i = 0; i < array.Length; i++)
	{
        first = array[i];
        
        remainder = s - first;

		for (int j = i + 1; j < array.Length; j++)
		{
            if(remainder == array[j])
            {
                second = array[j];
                return (first, second);
            }
        }
    }

    throw new Exception($"Нет пар которые в сумме образовывают {s}");
}