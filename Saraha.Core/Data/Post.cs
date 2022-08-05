using Saraha.Core.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Post
    {
        public Post()
        {
            Activities = new HashSet<Activity>();
            Postcomments = new HashSet<Postcomment>();
            Postlikes = new HashSet<Postlike>();
        }

        public decimal Postid { get; set; }
        public DateTime? Postdate { get; set; }
        public string Posttext { get; set; }
        public bool? IsPin { get; set; }
        public string Imagepath { get; set; }
        public decimal? Userid { get; set; }

        public virtual Userprofile User { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Postcomment> Postcomments { get; set; }
        public virtual ICollection<Postlike> Postlikes { get; set; }
    }
}
