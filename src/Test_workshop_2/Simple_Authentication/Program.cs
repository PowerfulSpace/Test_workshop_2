using Simple_Authentication.Data;
using Simple_Authentication.Services;

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("Добро пожаловать! Выберите действие:");
    Console.WriteLine("1. Зарегистрироваться");
    Console.WriteLine("2. Войти");

    string choice = Console.ReadLine()!;

    if (choice == "1")
    {
        UserRegistration.Register(db);
    }
    else if (choice == "2")
    {
        UserAuthentication.Authenticate(db);
    }
    else
    {
        Console.WriteLine("Неверный выбор.");
    }
}

Console.ReadLine();