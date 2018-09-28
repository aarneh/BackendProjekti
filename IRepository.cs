using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendProjekti
{
     public interface IRepository
    {
        //Players
        Task<User> Get(Guid id);
        Task<User[]> GetAll();
        Task<User> Create(User user);
        Task<User> Modify(Guid id, ModifiedUser user);
        Task<User> Delete(Guid id);
        //Items 
        Task<User> GetPost(Guid id, Guid postid);
        Task<User> GetPosts(Guid id);
        Task<User> Post(Guid id);
        Task<User> EditPost(Guid id, Guid postid, string editedPost);
        Task<User> DeletePost(Guid id, Guid postid);
    }
}