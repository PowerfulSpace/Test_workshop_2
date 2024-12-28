

int[] array = { 20, 23, 53, 69, 70, 10, 22, 69, 17, 69 };

QuickSort(array, 0, array.Length - 1);

Console.WriteLine(string.Join(", ",array));

Console.ReadLine();



void QuickSort(int[] array, int left, int rigth)
{
    if (left >= rigth) { return; }

    int pivot = GetPivot(array,left,rigth);

    QuickSort(array, left, pivot - 1);
    QuickSort(array, pivot + 1, rigth);
}

int GetPivot(int[] array, int left, int rigth)
{
    int i = left;

    while (left <= rigth)
    {
        if (array[left] < array[rigth])
        {
            Swap(array, i,left);
            i++;
        }
        left++;
    }

    Swap(array, i, rigth);

    return i;
}

void Swap(int[] arrat, int x, int y)
{
    int temp = arrat[x];
    arrat[x] = arrat[y];
    arrat[y] = temp;
}
