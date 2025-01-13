


var words = new[] { "apple", "banana", "pear", "cherry", "fig", "kiwi", "plum" };


var result = words.OrderBy(x => x.Length).GroupBy(x => x.Length);

foreach (var word in result)
{
    Console.Write($"Длина {word.Key}:");
    foreach (var word2 in word)
    {
        Console.Write($"{word2}, ");
    }
    Console.WriteLine();
}

var result2 = from x in words
              orderby x.Length
              group x by x.Length;


foreach (var word in result2)
{
    Console.Write($"Длина {word.Key}:");
    foreach (var word2 in word)
    {
        Console.Write($"{word2}, ");
    }
    Console.WriteLine();
}


Console.ReadLine();



