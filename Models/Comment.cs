using System;
using System.Collections.Generic;

namespace EasyFixMVC.Models
{
public class Comment
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }

    }

public class CustomModelComment {
        public List<Comment> CommentList {get;set;}
        public string Code {get;set;}
        public string Username {get;set;}
        public string CommentText {get;set;}

    }
}

