using Saraha.Core.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Login
    {
        public decimal Loginid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Userid { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBlocked { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Role Role { get; set; }
        public virtual Userprofile User { get; set; }
    }
}
