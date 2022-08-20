using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Purchase
    {
        public decimal PurchaseID { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? PurchaseCost { get; set; }
        public decimal? UserId { get; set; }
        public decimal? FeatureId { get; set; }

    }
}
