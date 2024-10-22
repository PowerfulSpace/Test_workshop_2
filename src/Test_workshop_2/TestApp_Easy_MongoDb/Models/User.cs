using MongoDB.Bson;

namespace TestApp_Easy_MongoDb.Models
{
    // Класс для представления документа в базе данных
    public class User
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
    }
}
