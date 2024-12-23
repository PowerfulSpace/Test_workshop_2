

int[] array = { 10, 20, -10, -20, 5, 8, 3, -15 };

Console.WriteLine(FindMaxProduct(array));

Console.ReadLine();


int FindMaxProduct(int[] array)
{
    if (array.Length < 2) { throw new Exception("Массив должен содержать хотя бы два элемента."); }
    if (array.Length == 2) { return array[0] * array[1]; }

    List<int> nums = array.ToList();
    nums.Sort();

    return nums[nums.Count - 1] * nums[nums.Count - 2];
}