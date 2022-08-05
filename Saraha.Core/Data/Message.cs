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
        public int messageID { get; set; }
        public string messageContent { get; set; }
    
        public string status { get; set; }
        public DateTime messageDate { get; set; }
        public int userFrom { get; set; }
        [ForeignKey("userFrom")]
        public virtual Userprofile Userprofile { get; set; }
        public int userTo { get; set; }
        [ForeignKey("userTo")]
        public virtual Userprofile Userprofile { get; set; }



    }
}
