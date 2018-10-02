using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BackendProjekti
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Admin { get; set; }
        public bool IsBanned { get; set; }
        public List<Post> Posts { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int Activity{get; set;}
        
       
    }

     public class NewUser
    {
        public string Name { get; set; }
    }

    public class ModifiedUser
    {
        public string Description { get; set; }
    }

    public class UserConverter : CustomCreationConverter<User>{
        public override User Create (Type objectType) {
            return new User();
        }
    }
}