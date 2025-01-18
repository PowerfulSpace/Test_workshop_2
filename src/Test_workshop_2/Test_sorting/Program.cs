

var students = new[]
{
    new { Name = "Алексей", Grades = new[] { 90, 85, 88 } },
    new { Name = "Мария", Grades = new[] { 75, 80, 78 } },
    new { Name = "Иван", Grades = new[] { 60, 65, 70 } },
    new { Name = "Ольга", Grades = new[] { 95, 92, 98 } }
};


var result = students
    .GroupBy(x => x.Grades.Average() % 10)
    .Select(x => new
    {
        Range = x.Key,
        Count = x.Count()
    });

foreach (var student in result)
{
    Console.WriteLine(student);
}

Console.ReadLine();


