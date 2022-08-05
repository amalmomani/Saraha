using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Service
    {
      
        public decimal Serviceid { get; set; }
        public string Servicename { get; set; }
        public decimal? Serviceprice { get; set; }
        public decimal? Serviceduration { get; set; }
    }
}
