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

        public Task<User> GetPost(Guid postid) {
            _repository.GetPost(postid);
            return _repository.GetPosts(postid);
        }
        
        public Task<User> GetPosts(Guid id) {
            _repository.GetPosts(id);
            return _repository.GetPosts(id);
        }
        
        public Task<User> Post(Guid id) {
            _repository.Post(id);
            return _repository.Post(id);
        }

        public Task<User> EditPost(Guid postid, string editedPost) {
            _repository.EditPost(postid, editedPost);
            return _repository.EditPost(postid, editedPost);
        }

        public Task<User> DeletePost(Guid postid) {
            _repository.DeletePost(postid);
            return _repository.DeletePost(postid);
        }
    }
}