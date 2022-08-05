using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Saraha.Core.Data
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string MessageContent { get; set; }
    
        public string Status { get; set; }
        public DateTime MessageDate { get; set; }
        public int UserFrom { get; set; }
        [ForeignKey("userFrom")]
        public virtual Userprofile Userfrom { get; set; }
        public int userTo { get; set; }
        [ForeignKey("userTo")]
        public virtual Userprofile UserTo { get; set; }
        public virtual Userprofile UserProfileFrom { get; set; }
        public int Userto { get; set; }
        [ForeignKey("userTo")]
        public virtual Userprofile UserprofileFrom { get; set; }



    }
}
