using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApp_Middle_MongoDb.Models
{
    public class Student
    {
        [BsonId]
        public ObjectId Id { get; set; } // Используем ObjectId вместо Guid
        public string Name { get; set; } = null!;
        public List<ObjectId> CourseIds { get; set; } = new List<ObjectId>(); // Список идентификаторов курсов
    }
}
