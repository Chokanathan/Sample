using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBATLAS.Services
{
    public class MongoDBService
	{
		private readonly IMongoCollection<TestData> _testData;
		public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
		{
			MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
			IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
			_testData = database.GetCollection<TestData>(mongoDBSettings.Value.CollectionName);
		}

		public async Task Insert(TestData testData)
		{
			await _testData.InsertOneAsync(testData);
			return;
		}

        public async Task<List<TestData>> Get() => await _testData.Find(new BsonDocument()).ToListAsync();
    }
}

