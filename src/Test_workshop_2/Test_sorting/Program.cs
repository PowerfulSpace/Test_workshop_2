
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

var result = employeesSet1.Intersect(employeesSet2);

var result2 = employeesSet1.Intersect(employeesSet2);



foreach (var employee in result)
{
    Console.WriteLine(employee);
}



Console.ReadLine();



