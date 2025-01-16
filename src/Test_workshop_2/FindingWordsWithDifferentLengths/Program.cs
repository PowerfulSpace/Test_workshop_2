var employeesSet1 = new[]
{
    new { Id = 1, Name = "Alice" },
    new { Id = 2, Name = "Bob" },
    new { Id = 3, Name = "Charlie" }
};

var employeesSet2 = new[]
{
    new { Id = 2, Name = "Bob" },
    new { Id = 3, Name = "Charlie" },
    new { Id = 4, Name = "David" }
};


var intersection = employeesSet1.Intersect(employeesSet2);


var difference = employeesSet1.Except(employeesSet2).Union(employeesSet2.Except(employeesSet1));

Console.Write("Пересечение:");
foreach (var employee in intersection)
{
    Console.Write($"[Id: {employee.Id}, Name: {employee.Name}], ");
}
Console.WriteLine();

Console.Write("Разность:");
foreach (var employee in difference)
{
    Console.Write($"[Id: {employee.Id}, Name: {employee.Name}], ");
}

Console.ReadLine();
