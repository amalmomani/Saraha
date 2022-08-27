using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Postlike
    {
      
        public int LikeId { get; set; }

        public DateTime? LikeDate { get; set; }
        public decimal? UserId { get; set; }
        public decimal? PostId { get; set; }

    }
}
