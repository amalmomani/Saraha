using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Home
    {
        public decimal Homeid { get; set; }
        public string Logo { get; set; }
        public string Background { get; set; }
        public string Text { get; set; }
        public decimal? Aboutusid { get; set; }
        public decimal? Contactusid { get; set; }

        public virtual Aboutus Aboutus { get; set; }
        public virtual Contactus Contactus { get; set; }
    }
}
