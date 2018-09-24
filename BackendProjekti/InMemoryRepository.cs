using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendProjekti
{
    public class InMemoryRepository: IRepository
    {
        public InMemoryRepository(){
            Player temp = new Player();
            temp.Name = "Markku";
            temp.Id = Guid.NewGuid();
            temp.Score = 0;
            temp.IsBanned = false;
            temp.CreationTime = DateTime.Now;
            players.Add(temp);
            
        }
        
        List<Player> players = new List<Player>();
        public Task<Player> Get(Guid id)
        { 
            for(int i = 0; i < players.Count;i++){
                if(players[i].Id==id){
                    return Task.FromResult(players[i]);
                }
            }
            return Task.FromResult((Player)null);
        }

        public Task<Player[]> GetAll()
        {
            /*Player[] temp = new Player[players.Count];
            
            for(int i = 0; i < players.Count;i++){
                temp[i] = players[i];
            }
            return Task.FromResult(temp);
            */
            return Task.FromResult(players.ToArray());
        }

        public Task<Player>Create(Player player)
        {
        
            players.Add(player);
            return Task.FromResult(player);
        }

        public Task<Player>Modify(Guid id, ModifiedPlayer player)
        {
            
            
            for(int i = 0; i < players.Count;i++){
                if(players[i].Id==id){
                    players[i].Score = player.Score;
                    return Task.FromResult(players[i]);
                }
            }
            
            return Task.FromResult((Player)null);
        }

        public Task<Player>Delete(Guid id)
        {
            Player tempplayer = new Player();
            for(int i = 0; i< players.Count; i++){
                if(players[i].Id == id){
                    players.Remove(players[i]);
                    return Task.FromResult(players[i]);
                }
            }
            return null;
        }

    }
}