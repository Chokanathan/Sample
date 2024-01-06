using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBATLAS.Models
{
    public class TestData
	{
		[BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string? Id { get; set; }
		public string Name { get; set; } = null!;
		public List<string> Hobbies { get; set; } = null!;
	}
}

