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

    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayersProcessor _processor;

        public PlayerController(PlayersProcessor processor)
        {
            _processor = processor;
        }
       

        // GET api/<controller>/5
        [Route("{id}")]
        [HttpGet]
        public Task<Player> Get(Guid id)
        {
            return _processor.Get(id);
            
        }

        // getaa api/<controller>
        [HttpGet]
        public Task<Player[]> GetAll()
        {
            return _processor.GetAll();
        }

        // PUT api/<controller>/5
        [Route("")]
        [HttpPost]
        public Task<Player> Create([FromBody]NewPlayer player)
        {
           // Console.WriteLine(player.Name);
            return _processor.Create(player);
        }
        
        //JOTAIN
        [Route("{id}")]
        [HttpPut]
        public Task<Player> Modify(Guid id,[FromBody]ModifiedPlayer player)
        {
            return _processor.Modify(id, player);
        }
        // DELETE api/<controller>/5'
        [Route("{id}")]
        [HttpDelete]
        public Task<Player> Delete(Guid id)
        {
            return _processor.Delete(id);
        }
        
    }
}
