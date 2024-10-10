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
            LoggingService.Log($"Пользователь {user.Username} просматривает курсы.");

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

        // Остальные методы остаются прежними, но добавим логирование и проверку роли из токена
        public void AddCourse(User user, string courseName)
        {
            if (user.Role != "Admin")
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

                LoggingService.Log($"Администратор {user.Username} добавил курс {courseName}.");
            }
        }

        public void AddStudent(User user, string studentName)
        {
            if (user.Role != "Admin")
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

                LoggingService.Log($"Администратор {user.Username} добавил студента {studentName}.");
            }
        }

        public void AssignStudentToCourse(User user, string studentName, string courseName)
        {
            if (user.Role != "Admin")
            {
                Console.WriteLine("У вас нет прав для добавления студентов на курсы.");
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var student = db.Students.FirstOrDefault(s => s.Name == studentName);
                var course = db.Courses.Include(c => c.Students).FirstOrDefault(c => c.Name == courseName);

                if (student == null)
                {
                    Console.WriteLine("Студент не найден.");
                    return;
                }

                if (course == null)
                {
                    Console.WriteLine("Курс не найден.");
                    return;
                }

                course.Students.Add(student);
                db.SaveChanges();
                Console.WriteLine($"Студент {studentName} добавлен на курс {courseName}.");

                LoggingService.Log($"Администратор {user.Username} назначил студента {studentName} на курс {courseName}.");
            }
        }
    }
}
