﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApp_Middle_MongoDb.Models
{
    public class Course
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ObjectId> StudentIds { get; set; } = new List<ObjectId>(); // Список идентификаторов студентов
    }
}
