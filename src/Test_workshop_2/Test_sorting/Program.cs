

int[] numbers = { 20, 23, 53, 69, 70, 10, 22, 69, 17, 69 };

QuickSort(numbers, 0, numbers.Length - 1);

Console.WriteLine(string.Join(", ", numbers));

Console.ReadLine();




void QuickSort(int[] array, int left, int right)
{
    if(left >= right) { return; }

    int pivot = Partition(array, left, right);


    Partition(array, left, pivot - 1);
    Partition(array, pivot + 1, right);
}

int Partition(int[] array, int left, int right)
{
    int pivot = array[right];
    int i = left - 1;

    for (int j = left; j < right; j++)
    {
        if (array[j] < pivot)
        {
            i++;
            Swap(array, i, j);
        }
    }

    Swap(array, i + 1, right);

    return i + 1;
}

void Swap(int[] array, int i, int j)
{
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}