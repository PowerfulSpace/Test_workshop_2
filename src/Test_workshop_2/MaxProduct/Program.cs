

int[] array = { 10, 20, -10, -20, 5, 8, 3, -15 };

Console.WriteLine(FindMaxProduct(array));

Console.ReadLine();


int FindMaxProduct(int[] array)
{
    if (array.Length < 2)
    {
        throw new Exception("Массив должен содержать хотя бы два элемента.");
    }

    List<int> nums = array.ToList();
    nums.Sort();

    int product1 = nums[nums.Count - 1] * nums[nums.Count - 2];
    int product2 = nums[0] * nums[1];

    return Math.Max(product1, product2);
}