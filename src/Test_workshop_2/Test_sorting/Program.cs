
var words = new[] { "Apple", "banana", "APPLE", "Banana", "ORANGE", "orange", "grape" };

var result = words.Select(x => x.ToLower()).Distinct();

foreach (var word in result)
{
    Console.Write(word + " ");
}

Console.ReadLine();



