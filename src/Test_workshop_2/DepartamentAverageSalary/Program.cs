

var employees = new[]
{
    new { Name = "Иван", Position = "Разработчик", Department = "ИТ", Salary = 100000 },
    new { Name = "Мария", Position = "Аналитик", Department = "Бизнес", Salary = 90000 },
    new { Name = "Петр", Position = "Разработчик", Department = "ИТ", Salary = 110000 },
    new { Name = "Анна", Position = "Менеджер", Department = "Маркетинг", Salary = 95000 }
};


var result = employees
    .GroupBy(x => x.Department)
    .Select(x => new
    {
        Departament = x.Key,
        SalaryAverange = x.Average(x => x.Salary)
    })
    .OrderByDescending(x => x.SalaryAverange)
    .FirstOrDefault();


if (result != null)
{
    Console.WriteLine($"Отдел с наивысшей средней зарплатой: {result.Departament} (Средняя зарплата: {result.SalaryAverange:F2})");
}

Console.ReadLine();

