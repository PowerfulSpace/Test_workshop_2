
var students = new[]
{
    new { StudentId = 1, Name = "Alice" },
    new { StudentId = 2, Name = "Bob" },
    new { StudentId = 3, Name = "Charlie" }
};

var enrollments = new[]
{
    new { StudentId = 1, Course = "Math" },
    new { StudentId = 2, Course = "Science" },
    new { StudentId = 1, Course = "History" },
    new { StudentId = 3, Course = "Math" }
};


//var result = students
//    .Join(enrollments, s => s.StudentId, e => e.StudentId, (s, e) => new
//    {
//        Name = s.Name,
//        Course = e.Course
//    })
//    .Where(x => x.Course == "Math");

var result = enrollments
    .Where(x => x.Course == "Math")
    .Join(students, e => e.StudentId, s => s.StudentId, (e, s) => new
    {
        Name = s.Name,
        Course = e.Course
    });


foreach (var item in result)
{
    Console.WriteLine($"Имя: {item.Name}, Курс: {item.Course}");
}


Console.ReadLine();



