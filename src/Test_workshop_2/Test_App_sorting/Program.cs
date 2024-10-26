int[] numbers = { 3, 12, 4, 10 };
var orderedNumbers = numbers.OrderBy(n => n);
foreach (int i in orderedNumbers)
    Console.WriteLine(i);

string[] people = { "Tom", "Bob", "Sam" };
var orderedPeople = people.OrderBy(p => p);
foreach (var p in orderedPeople)
    Console.WriteLine(p);

Console.ReadLine();