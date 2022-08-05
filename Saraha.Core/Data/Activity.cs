using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Saraha.Core.Data
{
   public class Activity
    {
        [Key]
        public int activityID { get; set; }
        public string message { get; set; } 
        public int userID { get; set; }
        //[ForeignKey("userID")]
        //public virtual UserProfile user { get; set; }
        public int likeID { get; set; }
        //[ForeignKey("likeID")]
        //public virtual PostLike like { get; set; }
        public int commentID { get; set; }
        //[ForeignKey("commentID")]
        //public virtual PostComment comment { get; set; }
        public int postID { get; set; }
        //[ForeignKey("postID")]
        //public virtual Post post { get; set; }
    }
}
