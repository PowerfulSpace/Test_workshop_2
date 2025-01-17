

var numberStrings = new[] { "123", "456", "789" };

var result = numberStrings.Select(x => x.Sum(c => int.Parse(c.ToString())));


foreach (var numberString in result)
{
    Console.Write(numberString + " ");
}

Console.ReadLine();


