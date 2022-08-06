using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Data
{
  public class Service
    {
        public decimal Serviceid { get; set; }
        public string Servicename { get; set; }
        public decimal? Serviceprice { get; set; }
        public decimal? Serviceduration { get; set; }
    }
}
