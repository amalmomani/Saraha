using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saraha.Core.Data
{
      public  class UserProfile
    {
        [Key]
        public int Userid { get; set; }
        [Required]
        public string Username { get; set; }

        [DataType(dataType: DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(dataType: DataType.PhoneNumber)]
        public string Phonenumber { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Country { get; set; }
        public string Imagepath { get; set; }
        public bool? IsPremium { get; set; }

      
    }
}
