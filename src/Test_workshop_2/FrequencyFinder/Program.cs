
var numbers = new[] { 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 5 };


var result = numbers
    .GroupBy(x => x)
    .Select(x => new
    {
        Num = x.Key,
        Count = x.Count()
    })
    .OrderByDescending(x => x.Count)
    .FirstOrDefault();

if (result != null)
{
    Console.WriteLine($"Элемент: {result.Num}, Количество вхождений: {result.Count}");
}



Console.ReadLine();


