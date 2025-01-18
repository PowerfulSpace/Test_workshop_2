
var employees = new[]
{
    new { Name = "Иван", Salary = 45000 },
    new { Name = "Мария", Salary = 75000 },
    new { Name = "Петр", Salary = 120000 },
    new { Name = "Анна", Salary = 95000 },
    new { Name = "Ольга", Salary = 50000 }
};

var result = employees
    .GroupBy(x => x.Salary < 50000
        ? "Менее 50 000"
        : x.Salary <= 100000
            ? "От 50 000 до 100 000"
            : "Более 100 000")
    .Select(g => new
    {
        Group = g.Key,
        Names = g.Select(x => x.Name).ToArray()
    });

Console.WriteLine("Группы сотрудников по диапазонам зарплат:");
foreach (var group in result)
{
    Console.WriteLine($"{group.Group}: {string.Join(", ", group.Names)}");
}

Console.ReadLine();
