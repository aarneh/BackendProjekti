using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
//using game_server.Players;

namespace BackendProjekti
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<User> _collection;
        private readonly IMongoCollection<string> _adminkey;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentAuthenticationkey;

        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase("userDatabase");
            _collection = database.GetCollection<User>("users");
            _adminkey = database.GetCollection<string>("authenticationkey");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("users");
            _bsonDocumentAuthenticationkey = database.GetCollection<BsonDocument>("authenticationkey");
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
            /*var data = _collection.Find(filter).FirstAsync().Result;
            string d = JsonConvert.SerializeObject(data);

            List<string> posts = new List<string>();
            foreach (string post in data.Posts) {
                posts.Add(post);
            }*/
            
            
            return _collection.Find(filter).FirstAsync();
        }

        public async Task<User> Modify(Guid id, ModifiedUser modifiedUser)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = await _collection.Find(filter).FirstAsync();
            user.Description = modifiedUser.Description;
            await _collection.ReplaceOneAsync(filter, user);
            return user;
        }

        public async Task<User> Delete(Guid UserId)
        {
            var filter = Builders<User>.Filter.Eq("_id", UserId);
            User user = await _collection.FindOneAndDeleteAsync(filter);
            return user;
        }

        public async Task<Post> GetPost(Guid id, Guid postid) {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = await _collection.Find(filter).FirstAsync();
            for (int i = 0; i < user.Posts.Count; i++) {
                if (user.Posts[i].postid == postid) {
                    return user.Posts[i];
                }
            }
            return null;
        }

        public async Task<Post[]> GetPosts(Guid id) {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = await _collection.Find(filter).FirstAsync();
            return user.Posts.ToArray();
        }
        
        public async Task<Post> Post(Guid id, NewPost newPost) {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = await _collection.Find(filter).FirstAsync();
            Post post = new Post();
            post.postString = newPost.postString;
            post.date = DateTime.Now;
            post.postid = Guid.NewGuid();
            user.Posts.Add(post);
            await _collection.ReplaceOneAsync(filter, user);
            return post;
        }

        public async Task<Post> EditPost(Guid id, Guid postid, string editedPost) {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = await _collection.Find(filter).FirstAsync();
            for (int i = 0; i < user.Posts.Count; i++) {
                if (user.Posts[i].postid == postid) {
                    user.Posts[i].postString = editedPost;
                    await _collection.ReplaceOneAsync(filter, user);
                    return user.Posts[i];
                }
            }
            return null;
        }
        
        public async Task<Post> DeletePost(Guid id, Guid postid) {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = await _collection.Find(filter).FirstAsync();
            for (int i = 0; i < user.Posts.Count; i++) {
                if (user.Posts[i].postid == postid) {
                    user.Posts.Remove(user.Posts[i]);
                    await _collection.ReplaceOneAsync(filter, user);
                    return user.Posts[i];
                }
            }
            return null;
        }

        public async Task<int> GetActivity(Guid id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = await _collection.Find(filter).FirstAsync();
            return user.Activity;
        }

        public async Task<User[]> GetUsersWithActivityMoreThan(int minactivity)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Gt("Activity", minactivity);
            List<User> users = await _collection.Find(filter).ToListAsync();
            return users.ToArray();
           
        }

        public async Task<User> GetMostActiveUser()
        {
            SortDefinition<User> sort = Builders<User>.Sort.Descending(p => p.Activity);
            User user = await _collection.Find(new BsonDocument()).Sort(sort).FirstAsync();
            return user;
        }

        public async Task<User> GetLeastActiveUser()
        {
            SortDefinition<User> sort = Builders<User>.Sort.Ascending(p => p.Activity);
            User user = await _collection.Find(new BsonDocument()).Sort(sort).FirstAsync();
            return user;
        }

        public async Task<int> GetAmountOfPosts(Guid id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", id);
            User user = await _collection.Find(filter).FirstAsync();
            return user.Posts.Count;
        }

        public async Task<User> BanUser(Guid id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("id", id);
            var banuser = Builders<User>.Update.Set("IsBanned", true);
            User user = await _collection.FindOneAndUpdateAsync(filter, banuser);
            return user;
        }

        public async Task<User> UnBanUser(Guid id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("id", id);
            var unbanuser = Builders<User>.Update.Set("IsBanned", false);
            User user = await _collection.FindOneAndUpdateAsync(filter, unbanuser);
            return user;
        }

        public async Task<Post> FavoritePost(Guid postid, Guid Favoriterid, Guid id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("id", id);
            User user = await _collection.Find(filter).FirstAsync();

            for (int i = 0; i < user.Posts.Count; i++) {
                if (user.Posts[i].postid == postid) {
                    user.Posts[i].Favorites.Add(Favoriterid);
                    await _collection.ReplaceOneAsync(filter, user);
                    return user.Posts[i];
                }
            }
            return null;
            
        }

        public async Task<Comment> CommentPost(Guid id,Guid postid, Comment comment)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("id", id);
            User user = await _collection.Find(filter).FirstAsync();
            for (int i = 0; i < user.Posts.Count; i++) {
                if (user.Posts[i].postid == postid) {
                    user.Posts[i].Comments.Add(comment);
                    await _collection.ReplaceOneAsync(filter, user);
                    return comment;
                }
            }
            return null;
        }

        public Task<Boolean> CheckIfAdmin(string adminkey)
        {
            if(adminkey == _adminkey.ToString())
            {
                return Task.FromResult(true);
            }else{
                return Task.FromResult(false);
            }
        }
    }
}
