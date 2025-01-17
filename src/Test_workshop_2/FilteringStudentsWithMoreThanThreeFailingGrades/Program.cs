
var students = new[]
{
    new { Name = "Алексей", Grades = new[] { 45, 55, 60, 40, 30 } },
    new { Name = "Мария", Grades = new[] { 85, 95, 80, 70, 90 } },
    new { Name = "Иван", Grades = new[] { 40, 35, 45, 50, 55 } }
};


var result = students
    .Where(x => x.Grades.Count(y => y < 50) == 3)
    .Select(x => x.Name);

Console.Write($"Студенты с более чем тремя неудовлетворительными оценками: ");

foreach (var student in result)
{
    Console.Write(student + " ");
}




Console.ReadLine();

