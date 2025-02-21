var employees = new[]
{
    new { Name = "Иван", Salary = 45000 },
    new { Name = "Мария", Salary = 75000 },
    new { Name = "Петр", Salary = 120000 },
    new { Name = "Анна", Salary = 95000 },
    new { Name = "Анна2", Salary = 98000 },
    new { Name = "Анна2", Salary = 98000 },
    new { Name = "Анна2", Salary = 98000 },
    new { Name = "Анна2", Salary = 98000 },
    new { Name = "Анна2", Salary = 98000 },
    new { Name = "Анна2", Salary = 98000 },
    new { Name = "Ольга", Salary = 50000 }
};

var sortedSalaries = employees
    .Select(x => x.Salary)
    .OrderBy(x => x)
    .ToList();

double median;
int count = sortedSalaries.Count;
if (count % 2 == 0)
{
    median = (sortedSalaries[count / 2 - 1] + sortedSalaries[count / 2]) / 2.0;
}
else
{
    median = sortedSalaries[count / 2];
}

Console.WriteLine($"Медианная зарплата по компании: {median}");

Console.ReadLine();

