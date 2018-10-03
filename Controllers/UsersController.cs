using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BackendProjekti
{
    
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UsersProcessor _processor;

        public UsersController(UsersProcessor processor)
        {
            _processor = processor;
        }
       

        
        [Route("{id}")]
        [HttpGet]
        public Task<User> Get(Guid id)
        {
            return _processor.Get(id);
        }

        
        [HttpGet]
        public Task<User[]> GetAll()
        {
            return _processor.GetAll();
        }

        
        [HttpPost]
        public Task<User> Create(NewUser user)
        {
            return _processor.Create(user);
        }

        

        
        
        [Route("{id}/{adminkey}")]
        [HttpPut]
        public Task<User> Modify(Guid id,[FromBody]ModifiedUser user,string adminkey)
        {
            if(_processor.CheckIfAdmin(adminkey).Result){
            return _processor.Modify(id, user);
            }else{
                throw new NotAdminException("You are not admin!");
            }
        }
        
        [Route("{id}")]
        [HttpDelete]
        public Task<User> Delete(Guid id,[FromBody]string adminkey)
        {
            if(_processor.CheckIfAdmin(adminkey).Result){
            return _processor.Delete(id);
            }else{
                throw new NotAdminException("You are not admin!");
            }
        }

        [Route("{id}/posts/{postid}")]
        [HttpGet]
        public Task<Post> GetPost(Guid id, Guid postid) {
            
            return _processor.GetPost(id, postid);
           
        }

        [Route("{id}/posts")]
        [HttpGet]
        public Task<Post[]> GetPosts(Guid id) {
            return _processor.GetPosts(id);
        }

        [Route("{id}/post")]
        [HttpPost]
        public Task<Post> Post(Guid id, NewPost newPost) {
            return _processor.Post(id, newPost);
        }

        [Route("{id}/posts/{postid}/edit")]
        [HttpPut]
        public Task<Post> EditPost(Guid id, Guid postid, string editedPost) {
            return _processor.EditPost(id, postid, editedPost);
        }

        [Route("{id}/posts/{postid}/delete")]
        [HttpDelete]
        public Task<Post> DeletePost(Guid id, Guid postid) {
            return _processor.DeletePost(id, postid);
        }

        [Route("activity/{id}")]
        [HttpGet]
        public Task<int> GetActivity(Guid id)
        {
            return _processor.GetActivity(id);
        }

        [Route("activity/{minactivity}")]
        [HttpGet]
        public Task<User[]> GetUsersWithActivityMoreThan(int minactivity)
        {
            return _processor.GetUsersWithActivityMoreThan(minactivity);
        }

        [Route("mostactivity")]
        [HttpGet]
        public Task<User> GetMostActiveUser()
        {
            return _processor.GetMostActiveUser();
        }

        [Route("leastactivity")]
        [HttpGet]
        public Task<User> GetLeastActiveUser()
        {
            return _processor.GetLeastActiveUser();
        }

        [Route("amountofposts/{id}")]
        [HttpGet]
        public Task<int> GetAmountOfPosts(Guid id)
        {
            return _processor.GetAmountOfPosts(id);
        }

        [Route("banuser/{id}")]
        [HttpPut]
        public Task<User> BanUser(Guid id,[FromBody]string adminkey)
        {
            if(_processor.CheckIfAdmin(adminkey).Result){
            return _processor.BanUser(id);
            }else{
                throw new NotAdminException("You are not admin!");
            }
        }

        [Route("unbanuser/{id}")]
        [HttpPut]
        public Task<User> UnBanUser(Guid id,[FromBody]string adminkey)
        {
            if(_processor.CheckIfAdmin(adminkey).Result){
            return _processor.UnBanUser(id);
            }else{
                throw new NotAdminException("You are not admin!");
            }
        }

        [Route("{id}/posts/{postid}/favorite")]
        [HttpPut]
        public Task<Post> FavoritePost(Guid postid,[FromBody] Guid Favoriterid, Guid id)
        {
            return _processor.FavoritePost(postid,Favoriterid, id);
        }

        [Route("{id}/posts/{postid}/comments")]
        [HttpPut]
        public Task<Comment> CommentPost(Guid id,Guid postid, [FromBody]NewComment newcomment)
        {
            return _processor.CommentPost(id, postid, newcomment);
        }
    }
}
