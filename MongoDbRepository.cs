using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
//using game_server.Players;

namespace BackendProjekti
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<User> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;

        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase("Users");
            _collection = database.GetCollection<User>("users");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("users");
        }

        public async Task<User> Create(User user)
        {
            await _collection.InsertOneAsync(user);
            return user;
        }

        public async Task<User[]> GetAll()
        {
            List<User> users = await _collection.Find(new BsonDocument()).ToListAsync();
            return users.ToArray();
        }

        public Task<User> Get(Guid id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            return _collection.Find(filter).FirstAsync();
        }

        public async Task<User> Modify(Guid id, ModifiedUser modifiedUser)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = await _collection.Find(filter).FirstAsync();
            await _collection.ReplaceOneAsync(filter, user);
            return user;
        }

        public async Task<User> Delete(Guid UserId)
        {
            var filter = Builders<User>.Filter.Eq("_id", UserId);
            User user = await _collection.FindOneAndDeleteAsync(filter);
            return user;
        }
    }
}
