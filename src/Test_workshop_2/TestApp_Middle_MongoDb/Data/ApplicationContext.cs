using MongoDB.Driver;
using TestApp_Middle_MongoDb.Models;

namespace TestApp_Middle_MongoDb.Data
{
    public class ApplicationContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationContext()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // Ваш URI для подключения
            _database = client.GetDatabase("Test_App_Middle_MongoDB_DB"); // Имя базы данных
        }

        public IMongoCollection<Course> Courses => _database.GetCollection<Course>("Courses");
        public IMongoCollection<Student> Students => _database.GetCollection<Student>("Students");
    }
}