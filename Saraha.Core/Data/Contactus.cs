using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Saraha.Core.Data
{
    public  class Contactus
    {
       
        public decimal Contactusid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
