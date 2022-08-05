using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Saraha.Core.Data
{
    public partial class Contactus
    {
        [Key]
        public int Contactusid { get; set; }
        public string Username { get; set; }

        [DataType(dataType: DataType.EmailAddress)]
        public string Email { get; set; }
        public string Message { get; set; }

    }
}
