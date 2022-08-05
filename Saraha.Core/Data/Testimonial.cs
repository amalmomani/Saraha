using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonialid { get; set; }
        public string Content { get; set; }
        public decimal? Stars { get; set; }
        public bool? IsAccepted { get; set; }
        public decimal? Userid { get; set; }

        public virtual Userprofile User { get; set; }
    }
}
