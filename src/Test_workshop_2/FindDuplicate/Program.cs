


int[] array = { 3, 7, 2, 3, 8, 1, 9, 7, 2, 10, 5, 6, 1, 4, 2 };


Array.ForEach(array, x => Console.Write(x + " "));
Console.WriteLine();

var result = FindDuplicate(array);

result.ForEach(x => Console.Write(x + " "));


Console.ReadLine();


List<int> FindDuplicate(int[] array)
{
    HashSet<int> set = new HashSet<int>();
    List<int> duplicate = new List<int>();

    foreach (var item in array)
    {
        if (!set.Contains(item))
        {
            set.Add(item);
        }
        else
        {
            duplicate.Add(item);

        }
    }

    return duplicate;
}

List<int> FindDuplicate2(int[] array)
{
    HashSet<int> set = new HashSet<int>();
    HashSet<int> duplicate = new HashSet<int>();

    foreach (var item in array)
    {
        if (!set.Contains(item))
        {
            set.Add(item);
        }
        else
        {
            if (!duplicate.Contains(item))
            {
                duplicate.Add(item);
            }
        }
    }
    return duplicate.ToList();
}