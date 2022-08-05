using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Postcomment
    {
        public Postcomment()
        {
            Activities = new HashSet<Activity>();
        }

        public decimal Commentid { get; set; }
        public DateTime? Commentdate { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Postid { get; set; }
        public string Commenttext { get; set; }
        public string Imagepath { get; set; }

        public virtual Post Post { get; set; }
        public virtual Userprofile User { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
