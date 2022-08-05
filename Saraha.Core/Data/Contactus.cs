using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Contactus
    {
        public Contactus()
        {
            Homes = new HashSet<Home>();
        }

        public decimal Contactusid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public virtual ICollection<Home> Homes { get; set; }
    }
}
