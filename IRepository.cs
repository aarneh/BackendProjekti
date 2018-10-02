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
        Task<Post> GetPost(Guid id, Guid postid);
        Task<Post[]> GetPosts(Guid id);
        Task<Post> Post(Guid id, NewPost newPost);
        Task<Post> EditPost(Guid id, Guid postid, string editedPost);
        Task<Post> DeletePost(Guid id, Guid postid);
        Task<int> GetActivity(Guid id);
        Task<User[]> GetUsersWithActivityMoreThan(int minactivity);
        Task<User> GetMostActiveUser();
        Task<User> GetLeastActiveUser();
        Task<int> GetAmountOfPosts(Guid id);
        Task<User> BanUser(Guid id);
        Task<User> UnBanUser(Guid id);
        
        
        
        
    }
}