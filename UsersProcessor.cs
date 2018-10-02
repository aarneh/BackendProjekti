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
            
            
            return _repository.Create(tempuser);
        }
        public Task<User> Modify(Guid id, ModifiedUser user){
            return _repository.Modify(id, user);
        }

        public Task<User> Delete(Guid id){
            _repository.Delete(id);
            return _repository.Get(id);
        }

        public Task<Post> GetPost(Guid id, Guid postid) {
            _repository.GetPost(id, postid);
            return _repository.GetPost(id, postid);
        }
        
        public Task<Post[]> GetPosts(Guid id) {
            _repository.GetPosts(id);
            return _repository.GetPosts(id);
        }
        
        public Task<Post> Post(Guid id, NewPost newPost) {
            _repository.Post(id, newPost);
            return _repository.Post(id, newPost);
        }

        public Task<Post> EditPost(Guid id, Guid postid, string editedPost) {
            _repository.EditPost(id, postid, editedPost);
            return _repository.EditPost(id, postid, editedPost);
        }

        public Task<Post> DeletePost(Guid id, Guid postid) {
            _repository.DeletePost(id, postid);
            return _repository.DeletePost(id, postid);
        }
    }
}