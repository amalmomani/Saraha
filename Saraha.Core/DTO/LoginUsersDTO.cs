using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
    public class LoginUsersDTO
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Imagepath { get; set; }
        public int Loginid { get; set; }
        public bool? Is_Blocked { get; set; }


    }
}
