using System;
using System.Collections.Generic;
using Saraha.Core.Data;

#nullable disable

namespace Saraha.Core.Data
{
    public class Aboutus
    {
        public Aboutus()
        {
            Homes = new HashSet<Home>();
        }

        public decimal Aboutusid { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Imagepath { get; set; }

        public virtual ICollection<Home> Homes { get; set; }
    }
}
