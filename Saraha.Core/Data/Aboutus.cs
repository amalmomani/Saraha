using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Saraha.Core.Data
{
    public class Aboutus
    {
       [Key]
        public decimal Aboutusid { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Imagepath { get; set; }
        public string Feature1 { get; set; }
        public string Feature2 { get; set; }
        public string Feature3 { get; set; }
        public string Feature1_Image { get; set; }
        public string Feature2_Image { get; set; }
        public string Feature3_Image { get; set; }

    }
}
