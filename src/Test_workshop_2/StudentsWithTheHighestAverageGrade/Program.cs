
var students = new[]
{
    new { Name = "Алексей", Grades = new[] { 90, 80, 70 } },
    new { Name = "Мария", Grades = new[] { 85, 95, 80 } },
    new { Name = "Иван", Grades = new[] { 70, 75, 65 } }
};

var result = students
    .Select(x => new
    {
        Name = x.Name,
        Average = x.Grades.Average()
    })
    .OrderByDescending(x => x.Average)
    .FirstOrDefault();

if (result != null)
{
    Console.WriteLine($"Студент с наивысшим средним баллом: {result.Name} (Средний балл: {result.Average:F2})");
}


Console.ReadLine();

