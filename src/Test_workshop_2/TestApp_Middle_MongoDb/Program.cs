using MongoDB.Driver;
using TestApp_Middle_MongoDb.Data;
using TestApp_Middle_MongoDb.Models;

ApplicationContext db = new ApplicationContext();

Console.WriteLine("Добро пожаловать!");

// Пересоздание базы данных (удаление и создание коллекций)
db.Courses.DeleteMany(FilterDefinition<Course>.Empty);
db.Students.DeleteMany(FilterDefinition<Student>.Empty);

// Создание и добавление моделей
Student tom = new Student { Name = "Tom" };
Student alice = new Student { Name = "Alice" };
Student bob = new Student { Name = "Bob" };
db.Students.InsertMany(new[] { tom, alice, bob });

Course algorithms = new Course { Name = "Алгоритмы" };
Course basics = new Course { Name = "Основы программирования" };
db.Courses.InsertMany(new[] { algorithms, basics });

// Добавляем к студентам курсы (сохраняя их идентификаторы)
tom.CourseIds.Add(algorithms.Id);
tom.CourseIds.Add(basics.Id);
alice.CourseIds.Add(algorithms.Id);
bob.CourseIds.Add(basics.Id);

// Обновляем студентов в базе данных
db.Students.ReplaceOne(s => s.Id == tom.Id, tom);
db.Students.ReplaceOne(s => s.Id == alice.Id, alice);
db.Students.ReplaceOne(s => s.Id == bob.Id, bob);

// Обновление курса у студента
var studentAlice = db.Students.Find(s => s.Name == "Alice").FirstOrDefault();
var courseAlgorithms = db.Courses.Find(c => c.Name == "Алгоритмы").FirstOrDefault();
var courseBasics = db.Courses.Find(c => c.Name == "Основы программирования").FirstOrDefault();

if (studentAlice != null && courseAlgorithms != null && courseBasics != null)
{
    // Удаление курса у студента
    studentAlice.CourseIds.Remove(courseAlgorithms.Id);
    // Добавление нового курса студенту
    studentAlice.CourseIds.Add(courseBasics.Id);
    // Обновляем студента в базе данных
    db.Students.ReplaceOne(s => s.Id == studentAlice.Id, studentAlice);
}

// Вывод всех курсов и студентов
var courses = db.Courses.Find(FilterDefinition<Course>.Empty).ToList();
foreach (var course in courses)
{
    Console.WriteLine($"Course: {course.Name}");
    // Выводим всех студентов для данного курса
    foreach (var studentId in course.StudentIds)
    {
        var student = db.Students.Find(s => s.Id == studentId).FirstOrDefault();
        if (student != null)
        {
            Console.WriteLine($"Name: {student.Name}");
        }
    }
    Console.WriteLine("-------------------");
}

Console.ReadLine();