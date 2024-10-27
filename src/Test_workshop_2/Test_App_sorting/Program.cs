

int[] numbers = { 3, 12, 4, 10 };
var orderedNumbers = numbers.OrderBy(n => n);
foreach (int i in orderedNumbers)
    Console.WriteLine(i);


Console.ReadLine();