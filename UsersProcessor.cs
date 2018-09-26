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
    }
}