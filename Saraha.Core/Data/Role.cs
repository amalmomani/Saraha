using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Saraha.Core.Data
{
    public class Role
    {
       [Key]
        public decimal Roleid { get; set; }
        public string Rolename { get; set; }
    }
}
