using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
 public  class RegisterDTO
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phonenumber { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Country { get; set; }
        public string Imagepath { get; set; }
        public bool? Is_Premium { get; set; }

    }
}
