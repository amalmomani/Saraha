﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saraha.Core.Data
{
    public partial class Userprofile
    {
        [Key]
        public int Userid { get; set; }
        [Required]
        public string Username { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Country { get; set; }
        public string Imagepath { get; set; }
        public bool? Is_Premium { get; set; }

    }
}
