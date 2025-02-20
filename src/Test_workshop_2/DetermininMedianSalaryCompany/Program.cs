var employees = new[]
{
    new { Name = "Иван", Salary = 45000 },
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

