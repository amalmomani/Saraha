using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Saraha.Core.Data
{
    public interface VisaCard
    {
        [Key]
        public int paymentID { get; set; }
        public string CVV { get; set; }
        public string cardNumber { get; set; }
        public double balance { get; set; }
        public DateTime expirationDate { get; set; }
    }
}
