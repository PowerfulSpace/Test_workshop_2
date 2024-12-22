




int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23};


List<int> result = FindSimpleNum(array);


foreach (int i in result)
{
    Console.Write(i + " ");
}


Console.ReadLine();




List<int> FindSimpleNum(int[] array)
{
    List<int> result = new List<int>();

    foreach (int number in array)
    {
        if (number <= 1) continue;

        bool isSimple = true;

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isSimple = false;
                break;
            }
        }

        if (isSimple)
        {
            result.Add(number);
        }
    }

    return result;
}