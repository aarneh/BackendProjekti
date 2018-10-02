using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendProjekti
{
    public class Comment
    {
        public string CommentText{get; set;}
        public Guid CommentId{get; set;}
        public Guid CommenterId{get; set;}

    }

    public class NewComment
    {
        public string CommentText{get; set;}
        public Guid CommenterId{get;set;}
    }
    public class ModifiedComment
    {
        public string CommentText{get; set;}
    }
}