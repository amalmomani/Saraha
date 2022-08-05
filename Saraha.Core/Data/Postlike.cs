using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Postlike
    {
      
        public decimal Likeid { get; set; }
        public DateTime? Likedate { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Postid { get; set; }

    }
}
