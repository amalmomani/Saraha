using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Saraha.Core.Data
{
    public class VisaCard
    {
        [Key]
        public int PaymentID { get; set; }
        public string CVV { get; set; }
        public string CardNumber { get; set; }
        public double Balance { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
