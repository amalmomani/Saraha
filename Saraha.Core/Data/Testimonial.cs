using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Saraha.Core.Data
{
    public  class Testimonial
    {
        [Key]
        public int Testimonialid { get; set; }
        public string Content { get; set; }
        public int Stars { get; set; }
        public int Is_Accepted { get; set; }
        public int Userid { get; set; }
    }
}
