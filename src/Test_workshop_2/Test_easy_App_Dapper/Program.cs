using Dapper;
using System.Data.SqlClient;
using Test_easy_App_Dapper.Models;

string connectionString = "YourConnectionStringHere";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    // Выполнение SQL-запроса и сопоставление результата с объектом C#
    var users = connection.Query<User>("SELECT * FROM Users").ToList();

    foreach (var user in users)
    {
        Console.WriteLine($"{user.Id}: {user.Name}");
    }
}

Console.ReadLine();