using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendProjekti
{
     public interface IRepository
    {
        //Players
        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);
        //Items 
        

    }
}