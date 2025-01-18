var employees = new[]
{
    new { Name = "Иван", Department = "ИТ", Salary = 100000 },
    new { Name = "Мария", Department = "ИТ", Salary = 90000 },
    new { Name = "Петр", Department = "ИТ", Salary = 110000 },
    new { Name = "Анна", Department = "Маркетинг", Salary = 95000 },
    new { Name = "Ольга", Department = "Маркетинг", Salary = 90000 }
};

var result = employees
    .GroupBy(x => x.Department)
    .SelectMany(g =>
    {
        var averageSalary = g.Average(emp => emp.Salary);
        return g.Where(emp => emp.Salary > averageSalary);
    });

Console.WriteLine("Сотрудники с зарплатой выше средней по отделу:");
foreach (var employee in result)
{
    Console.WriteLine($"{employee.Name} ({employee.Department})");
}

Console.ReadLine();

