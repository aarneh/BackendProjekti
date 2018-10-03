using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendProjekti
{
    public class UsersProcessor
    {
        private readonly IRepository _repository;

        public UsersProcessor(IRepository repository)
        {
            _repository = repository;
        }
        public Task<User> Get(Guid id){
            return _repository.Get(id);
        }
        public Task<User[]> GetAll(){
            return _repository.GetAll();
        }
        public Task<User> Create(NewUser user){
            
            User tempuser = new User();
            
            tempuser.Name = user.Name;
            tempuser.Id = Guid.NewGuid();
            tempuser.IsBanned = false;
            tempuser.Posts = new List<Post>();
            tempuser.CreationTime = DateTime.Now;
            tempuser.Activity = 0;
            
            
            return _repository.Create(tempuser);
        }

        
        public Task<User> Modify(Guid id, ModifiedUser user){
            return _repository.Modify(id, user);
        }

        public Task<User> Delete(Guid id){
            return _repository.Delete(id);
        }

        public Task<Post> GetPost(Guid id, Guid postid) {
            return _repository.GetPost(id, postid);
        }
        
        public Task<Post[]> GetPosts(Guid id) {
            return _repository.GetPosts(id);
        }
        
        public Task<Post> Post(Guid id, NewPost newPost) {
            return _repository.Post(id, newPost);
        }

        public Task<Post> EditPost(Guid id, Guid postid, string editedPost) {
            return _repository.EditPost(id, postid, editedPost);
        }

        public Task<Post> DeletePost(Guid id, Guid postid) {
             return _repository.DeletePost(id, postid);
        }

        public Task<int> GetActivity(Guid id)
        {
            return _repository.GetActivity(id);
        }

        public Task<User[]> GetUsersWithActivityMoreThan(int minactivity)
        {
            return _repository.GetUsersWithActivityMoreThan(minactivity);
        }

        public Task<User> GetMostActiveUser()
        {
            return _repository.GetMostActiveUser();
        }

        public Task<User> GetLeastActiveUser()
        {
            return _repository.GetLeastActiveUser();
        }

        public Task<int> GetAmountOfPosts(Guid id)
        {
            return _repository.GetAmountOfPosts(id);
        }

        public Task<User> BanUser(Guid id)
        {
            return _repository.BanUser(id);
        }

        public Task<User> UnBanUser(Guid id)
        {
            return _repository.UnBanUser(id);
        }

        public Task<Post> FavoritePost(Guid postid, Guid Favoriterid, Guid id)
        {
            return _repository.FavoritePost(postid,Favoriterid,id);
        }

        public Task<Comment> CommentPost(Guid id,Guid postid, NewComment newcomment)
        {
            Comment tempcomment = new Comment();

            tempcomment.CommenterId = newcomment.CommenterId;
            tempcomment.CommentId = Guid.NewGuid();
            tempcomment.CommentText = newcomment.CommentText;

            return _repository.CommentPost(id, postid, tempcomment);
        }

        public Task<Boolean> CheckIfAdmin(string adminkey)
        {
            return _repository.CheckIfAdmin(adminkey);
        }
    }
}