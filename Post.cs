using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendProjekti
{
    public class Post
    {
        public Guid postid { get; set; }
        public DateTime date { get; set; }
        public string postString { get; set; }
    }

    public class NewPost
    {
        public string postString { get; set; }
    }

    public class ModifiedPost
    {
        public string postString { get; set; }
    }
}