using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendProjekti
{
    public class PlayersProcessor
    {
        private readonly IRepository _repository;

        public PlayersProcessor(IRepository repository)
        {
            _repository = repository;
        }
        public Task<Player> Get(Guid id){
            return _repository.Get(id);
        }
        public Task<Player[]> GetAll(){
            return _repository.GetAll();
        }
        public Task<Player> Create(NewPlayer player){
            
            Player tempplayer = new Player();
            
            tempplayer.Name = player.Name;
            tempplayer.Id = Guid.NewGuid();
            tempplayer.Score = 0;
            //Leveli
            tempplayer.IsBanned = false;
            tempplayer.CreationTime = DateTime.Now; 
            
            
            return _repository.Create(tempplayer);
        }
        public Task<Player> Modify(Guid id, ModifiedPlayer player){
            
            return _repository.Modify(id, player);
        }

        public Task<Player> Delete(Guid id){
            _repository.Delete(id);
            return _repository.Get(id);
        }
    }
}