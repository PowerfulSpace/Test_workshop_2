
Console.WriteLine("Сортировка пузырьком");
Console.Write("Введите элементы массива: ");
var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
var array = new int[parts.Length];
for (int i = 0; i < parts.Length; i++)
{
    array[i] = Convert.ToInt32(parts[i]);
}

Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", BubbleSort(array)));

Console.ReadLine();


//метод обмена элементов
static void Swap(ref int e1, ref int e2)
{
    var temp = e1;
    e1 = e2;
    e2 = temp;
}

//сортировка пузырьком
static int[] BubbleSort(int[] array)
{
    var len = array.Length;
    for (var i = 1; i < len; i++)
    {
        for (var j = 0; j < len - i; j++)
        {
            if (array[j] > array[j + 1])
            {
                Swap(ref array[j], ref array[j + 1]);
            }
        }
    }

    return array;
}