using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Saraha.Core.Data
{
    public class Aboutus
    {
        [Key]
        public int Aboutusid { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Imagepath { get; set; }
    }
}
