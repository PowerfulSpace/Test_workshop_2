

var employees = new[]
{
    new { Name = "Иван", Position = "Разработчик", Salary = 100000 },
    new { Name = "Мария", Position = "Аналитик", Salary = 90000 },
    new { Name = "Петр", Position = "Разработчик", Salary = 110000 },
    new { Name = "Анна", Position = "Менеджер", Salary = 95000 },
    new { Name = "Ольга", Position = "Аналитик", Salary = 85000 }
};

var result = employees
    .GroupBy(x => x.Position)
    .Select(x => new
    {
        Position = x.Key,
        SalaryAverage = x.Average(x => x.Salary)
    });

var min = result.OrderBy(x => x.SalaryAverage).FirstOrDefault();
var max = result.OrderByDescending(x => x.SalaryAverage).FirstOrDefault();


Console.WriteLine($"Должность с наивысшей средней зарплатой: {max.Position}");
Console.WriteLine($"Должность с наименьшей средней зарплатой: {min.Position}");



Console.ReadLine();


