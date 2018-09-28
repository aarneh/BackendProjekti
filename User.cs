using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendProjekti
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Admin { get; set; }
        public bool IsBanned { get; set; }
        public List<String> Posts { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
       
    }

     public class NewUser
    {
        public string Name { get; set; }
    }

    public class ModifiedUser
    {
        public string Description { get; set; }
    }
}