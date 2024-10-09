using Average_Authentication.Data;
using Average_Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace Average_Authentication.Services
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
    }
}
