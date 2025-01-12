

//Написать LINQ-запрос для группировки списка сотрудников по их должности.

// Список сотрудников
var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Position = "Manager" },
            new Employee { Id = 2, Name = "Bob", Position = "Developer" },
            new Employee { Id = 3, Name = "Charlie", Position = "Developer" },
            new Employee { Id = 4, Name = "Diana", Position = "Manager" },
            new Employee { Id = 5, Name = "Eve", Position = "Designer" },
        };



var result = employees.GroupBy(x => x.Position);


foreach (var group in result)
{
    Console.WriteLine(group.Key);
    foreach (var employee in group)
    {
        Console.WriteLine(employee.Name);
    }
    Console.WriteLine();
}




Console.ReadLine();



public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
}