string[] people = { "Tom", "Bob", "Sam" };
var orderedPeople = from p in people orderby p select p;
foreach (var p in orderedPeople)
    Console.WriteLine(p);       // Bob Sam Tom

Console.ReadLine();