
var items = Enumerable.Range(1, 100); // Коллекция чисел от 1 до 100
int pageNumber = 3;
int pageSize = 10;


var result = items.Skip(pageNumber * pageSize).Take(pageSize);

Console.Write($"Страница {pageNumber}: ");
Console.WriteLine(string.Join(", ", result));


Console.ReadLine();



