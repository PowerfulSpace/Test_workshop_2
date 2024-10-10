using Microsoft.EntityFrameworkCore;
using Strong_Authentication.Data;
using Strong_Authentication.Models;

namespace Strong_Authentication.Services
{
    public class CourseService
    {
        // Метод для вывода доступных курсов
        public void ShowCourses(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Courses.Include(c => c.Students).ToList();

                Console.WriteLine("Доступные курсы:");
                foreach (var course in courses)
                {
                    Console.WriteLine($"Курс: {course.Name}");
                    foreach (Student student in course.Students)
                    {
                        Console.WriteLine($"Студент: {student.Name}");
                    }
                    Console.WriteLine("-------------------");
                }
            }
        }

        // Метод для добавления курса (только для администратора)
        public void AddCourse(User admin, string courseName)
        {
            if (admin.Role != "Admin")
            {
                Console.WriteLine("У вас нет прав для добавления курсов.");
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                Course newCourse = new Course
                {
                    Id = Guid.NewGuid(),
                    Name = courseName
                };

                db.Courses.Add(newCourse);
                db.SaveChanges();
                Console.WriteLine($"Курс {courseName} добавлен.");
            }
        }

        // Метод для добавления студента (только для администратора)
        public void AddStudent(User admin, string studentName)
        {
            if (admin.Role != "Admin")
            {
                Console.WriteLine("У вас нет прав для добавления студентов.");
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                Student newStudent = new Student
                {
                    Id = Guid.NewGuid(),
                    Name = studentName
                };

                db.Students.Add(newStudent);
                db.SaveChanges();
                Console.WriteLine($"Студент {studentName} добавлен.");
            }
        }


        // Метод для добавления студента на курс (только для администратора)
        public void AssignStudentToCourse(User admin, string studentName, string courseName)
        {
            if (admin.Role != "Admin")
            {
                Console.WriteLine("У вас нет прав для добавления студентов на курсы.");
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var student = db.Students.FirstOrDefault(s => s.Name == studentName);
                var course = db.Courses.Include(c => c.Students).FirstOrDefault(c => c.Name == courseName);

                if (student == null || course == null)
                {
                    Console.WriteLine("Студент или курс не найдены.");
                    return;
                }

                course.Students.Add(student);
                db.SaveChanges();
                Console.WriteLine($"Студент {studentName} добавлен на курс {courseName}.");
            }
        }
    }
}
