// Подключение к серверу MongoDB (локально)
using MongoDB.Bson;
using MongoDB.Driver;
using TestApp_Easy_MongoDb.Models;

var client = new MongoClient("mongodb://localhost:27017");

// Выбираем базу данных (создается автоматически, если её нет)
var database = client.GetDatabase("testdb");

// Выбираем коллекцию (таблицу в реляционных базах) пользователей
var collection = database.GetCollection<User>("users");

// Создаем нового пользователя
var newUser = new User { Name = "Alice1", Age = 26 };

// Вставляем документ в коллекцию
await collection.InsertOneAsync(newUser);
Console.WriteLine("User inserted");

// Чтение данных из коллекции
var users = await collection.Find(new BsonDocument()).ToListAsync();
foreach (var user in users)
{
    Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Age: {user.Age}");
}

Console.WriteLine("Done");

Console.ReadLine();