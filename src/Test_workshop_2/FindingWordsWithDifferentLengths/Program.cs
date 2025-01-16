
var words = new[] { "apple", "banana", "cherry", "date", "fig", "grape" };

var result = words
    .GroupBy(x => x.Length)
    .Select(x => new
    {
        Length = x.Key,
        Count = x.Count()
    })
    .OrderByDescending(x => x.Count);

foreach (var word in result)
{
    Console.WriteLine($"Длина: {word.Length}, Количество слов: {word.Count}");
}

Console.ReadLine();