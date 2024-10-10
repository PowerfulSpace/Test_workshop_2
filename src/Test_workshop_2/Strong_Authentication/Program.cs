using Strong_Authentication.Models;
using Strong_Authentication.Services;

Console.WriteLine("Выберите действие:");
Console.WriteLine("1. Регистрация");
Console.WriteLine("2. Аутентификация");

int action = int.Parse(Console.ReadLine()!);

if (action == 1)
{
    Console.Write("Введите имя пользователя: ");
    string username = Console.ReadLine()!;

    Console.Write("Введите пароль: ");
    string password = Console.ReadLine()!;

    Console.Write("Введите роль (Admin или User): ");
    string role = Console.ReadLine()!;

    AuthService.Register(username, password, role);
}
else if (action == 2)
{
    Console.Write("Введите имя пользователя: ");
    string username = Console.ReadLine()!;

    Console.Write("Введите пароль: ");
    string password = Console.ReadLine()!;

    string? token = AuthService.Authenticate(username, password);

    if (token != null)
    {
        User user = AuthService.GetUserFromToken(token)!;
        if (user != null)
        {
            Console.WriteLine($"Добро пожаловать, {user.Username}! Ваша роль: {user.Role}");
            CourseService courseService = new CourseService();

            if (user.Role == "Admin")
            {
                while (true)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Показать курсы");
                    Console.WriteLine("2. Добавить курс");
                    Console.WriteLine("3. Добавить студента");
                    Console.WriteLine("4. Назначить студента на курс");
                    Console.WriteLine("5. Выйти");

                    int adminAction = int.Parse(Console.ReadLine()!);

                    if (adminAction == 1)
                    {
                        courseService.ShowCourses(user);
                    }
                    else if (adminAction == 2)
                    {
                        Console.Write("Введите название курса: ");
                        string courseName = Console.ReadLine()!;
                        courseService.AddCourse(user, courseName);
                    }
                    else if (adminAction == 3)
                    {
                        Console.Write("Введите имя студента: ");
                        string studentName = Console.ReadLine()!;
                        courseService.AddStudent(user, studentName);
                    }
                    else if (adminAction == 4)
                    {
                        Console.Write("Введите имя студента: ");
                        string studentName = Console.ReadLine()!;

                        Console.Write("Введите название курса: ");
                        string courseName = Console.ReadLine()!;

                        courseService.AssignStudentToCourse(user, studentName, courseName);
                    }
                    else if (adminAction == 5)
                    {
                        Console.WriteLine("Выход из системы...");
                        break;
                    }
                }
            }
            else
            {
                courseService.ShowCourses(user);
            }
        }
    }
}


Console.ReadLine();