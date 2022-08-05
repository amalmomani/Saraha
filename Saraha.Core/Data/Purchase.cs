using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Purchase
    {
        public decimal Purchaseid { get; set; }
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }
        public decimal? Purchasecost { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Serviceid { get; set; }

    }
}
