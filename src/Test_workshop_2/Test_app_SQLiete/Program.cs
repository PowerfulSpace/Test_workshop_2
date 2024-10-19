// Указание пути к базе данных (если файла не существует, он будет создан)
using Test_app_SQLiete.Data;
using Test_app_SQLiete.Models;


using (var db = new AppDbContext())
{
    db.Database.EnsureCreated(); // Создание базы данных и таблиц, если они не существуют

    // Добавление пользователя
    db.Users.Add(new User { Name = "Alx", Age = 26 });
    db.SaveChanges();

    // Запрос пользователей
    foreach (var user in db.Users)
    {
        Console.WriteLine($"{user.Id}: {user.Name} - {user.Age} years old");
    }
}

Console.ReadLine();