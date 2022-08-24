using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
    public class PostUserComment
    {
        public string Auther { get; set; }
        public string CommentFrom { get; set; }
        public DateTime PostDate { get; set; }
        public string PostText { get; set; }
        public string Is_pin { get; set; }
        public string PostImage { get; set; }
        public string CommentText { get; set; }
        public string CommentImage { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
