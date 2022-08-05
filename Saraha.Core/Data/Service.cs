using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Service
    {
        public Service()
        {
            Purchases = new HashSet<Purchase>();
        }

        public decimal Serviceid { get; set; }
        public string Servicename { get; set; }
        public decimal? Serviceprice { get; set; }
        public decimal? Serviceduration { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
