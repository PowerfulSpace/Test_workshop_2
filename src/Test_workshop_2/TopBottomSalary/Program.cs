
var employees = new[]
{
    new { Name = "Alice", Department = "HR", Salary = 60000 },
    new { Name = "Bob", Department = "IT", Salary = 80000 },
    new { Name = "Charlie", Department = "HR", Salary = 70000 },
    new { Name = "David", Department = "IT", Salary = 90000 },
    new { Name = "Eve", Department = "Finance", Salary = 75000 }
};

//var result = employees
//    .GroupBy(x => x.Department)
//    .Select(x => new
//    {
//        Departament = x.Key,
//        MinSalaryEmployee = x.OrderBy(x => x.Salary).First(),
//        MaxSalaryEmployee = x.OrderByDescending(x => x.Salary).First()
//    });



var result = employees
    .GroupBy(x => x.Department)
    .Select(x =>
    {
        var minSalary = x.Min(e => e.Salary);
        var maxSalary = x.Max(e => e.Salary);

        return new
        {
            Departament = x.Key,
            MinSalaryEmployee = x.Where(x => x.Salary == minSalary).First(),
            MaxSalaryEmployee = x.Where(x => x.Salary == maxSalary).First()
        };
    });


foreach (var employee in result)
{
    Console.WriteLine($"Department: {employee.Departament}, MinSalaryEmployee: {employee.MinSalaryEmployee.Name}, MinSalaryEmployee: {employee.MaxSalaryEmployee.Name}");
}

Console.ReadLine();