
int[] array = { 4, 5, -2, 1, -3, 4, -1, 2, 1, -5, 4 };

int result = 0;


result = FindSumSubarray(array);
Console.WriteLine(result);

result = FindSumSubarray2(array, int.MinValue, 0);
Console.WriteLine(result);

Console.ReadLine();




int FindSumSubarray(int[] array)
{
    int maxSum = int.MinValue;
    int sum = 0;

    for (int i = 0; i < array.Length; i++)
    {

        sum += array[i];

        if (sum > maxSum)
        {
            maxSum = sum;
        }

        if (sum < 0)
        {
            sum = 0;
        }

    }

    return maxSum;
}



int FindSumSubarray2(int[] array, int maxSum, int index)
{
    if (index > array.Length - 1)
    {
        return maxSum;
    }

    int sum = 0;

    for (int i = index; i < array.Length; i++)
    {
        sum += array[i];

        if (sum > maxSum) { maxSum = sum; }
    }

    maxSum = FindSumSubarray2(array, maxSum, index + 1);

    return maxSum;
}


