using Saraha.Core.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Post
    {
        public decimal Postid { get; set; }
        public DateTime? Postdate { get; set; }
        public string Posttext { get; set; }
        public bool? Is_Pin { get; set; }
        public string Imagepath { get; set; }
        public decimal? Userid { get; set; }

    }
}
