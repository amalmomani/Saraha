using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Saraha.Core.Data
{
    public  class Login
    {
        [Key]
        public int Loginid { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBlocked { get; set; }
        public int? Roleid { get; set; }

        [ForeignKey("Roleid")]
        public virtual Role Role { get; set; }

        public int? Userid { get; set; }

        [ForeignKey("Userid")]
        public virtual UserProfile Userprofile { get; set; }


    }
}
