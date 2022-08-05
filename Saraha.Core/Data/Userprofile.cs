using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Userprofile
    {
      
        public decimal Userid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Country { get; set; }
        public string Imagepath { get; set; }
        public bool? IsPremium { get; set; }

      
    }
}
