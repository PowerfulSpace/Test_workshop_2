

var numbers = new[] { 1, 2, 3, 4, 5 };
int windowSize = 3;


var result = numbers
    .Select((num, index) => new { Num = num, Index = index })
    .Where(x => x.Index >= numbers.Length - windowSize)
    .Select(x => numbers.Skip(x.Index).Take(windowSize).Average());

foreach (var item in result)
{
    Console.WriteLine(item);
}

Console.ReadLine();

