
int[] numbers = { 4, 5, 6, 7, 4, 3, 2, 4, 5, 5, 8, 9, 4 };

Console.WriteLine(FindMostFrequentNumber(numbers));

Console.ReadLine();


int FindMostFrequentNumber(int[] numbers)
{
    Dictionary<int, int> nums = new Dictionary<int, int>();

    foreach (int number in numbers)
    {
        if (nums.ContainsKey(number))
        {
            nums[number]++;
        }
        else
        {
            nums.Add(number, 1);
        }
    }

    int result = nums.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

    return result;
}