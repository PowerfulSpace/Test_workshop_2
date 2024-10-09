

using Average_Authentication.Models;
using Average_Authentication.Services;

Console.WriteLine("Выберите действие: ");
Console.WriteLine("1. Регистрация");
Console.WriteLine("2. Аутентификация");

int action = int.Parse(Console.ReadLine()!);

if (action == 1)
{
    Console.Write("Введите имя пользователя: ");
    string username = Console.ReadLine()!;

    Console.Write("Введите пароль: ");
    string password = Console.ReadLine()!;

    AuthService.Register(username, password);
}
else if (action == 2)
{
    Console.Write("Введите имя пользователя: ");
    string username = Console.ReadLine()!;

    Console.Write("Введите пароль: ");
    string password = Console.ReadLine()!;

    User? user = AuthService.Authenticate(username, password);

    if (user != null)
    {
        Console.WriteLine($"Добро пожаловать, {user.Username}! Ваша роль: {user.Role}");

        CourseService courseService = new CourseService();
        courseService.ShowCourses(user);
    }
}


Console.ReadLine();