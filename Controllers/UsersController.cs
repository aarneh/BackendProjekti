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

    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UsersProcessor _processor;

        public UsersController(UsersProcessor processor)
        {
            _processor = processor;
        }
       

        // GET api/<controller>/5
        [Route("{id}")]
        [HttpGet]
        public Task<User> Get(Guid id)
        {
            return _processor.Get(id);
        }

        // getaa api/<controller>
        [HttpGet]
        public Task<User[]> GetAll()
        {
            return _processor.GetAll();
        }

        // PUT api/<controller>/5
        [Route("")]
        [HttpPost]
        public Task<User> Create([FromBody]NewUser user)
        {
            return _processor.Create(user);
        }
        
        //JOTAIN
        [Route("{id}")]
        [HttpPut]
        public Task<User> Modify(Guid id,[FromBody]ModifiedUser user)
        {
            return _processor.Modify(id, user);
        }
        // DELETE api/<controller>/5'
        [Route("{id}")]
        [HttpDelete]
        public Task<User> Delete(Guid id)
        {
            return _processor.Delete(id);
        }
        
    }
}
