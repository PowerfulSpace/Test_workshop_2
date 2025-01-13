
var fruits = new[] { "apple", "banana", "apple", "orange", "banana", "grape", "apple" };

var result = fruits
    .GroupBy(x => x)
    .OrderByDescending(x => x.Count())
    .Select(x => new
    {
        Name = x.Key,
        Count = x.Count()
    });

foreach (var fruit in result)
{
    Console.WriteLine(fruit.Name + ": " + fruit.Count);
}

Console.ReadLine();



