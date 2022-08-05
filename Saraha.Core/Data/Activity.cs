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
        public int ActivityID { get; set; }
        public string Message { get; set; } 
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserProfile UserProfile { get; set; }
        public int LikeId { get; set; }
        [ForeignKey("LikeId")]
        public virtual Postlike Like { get; set; }
        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Postcomment Postcomment { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
