using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Postlike
    {
        public Postlike()
        {
            Activities = new HashSet<Activity>();
        }

        public decimal Likeid { get; set; }
        public DateTime? Likedate { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Postid { get; set; }

        public virtual Post Post { get; set; }
        public virtual Userprofile User { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
