int[] numbers = { 3, 12, 4, 10 };
var orderedNumbers = from i in numbers
                     orderby i
                     select i;
foreach (int i in orderedNumbers)
    Console.WriteLine(i);

Console.ReadLine();