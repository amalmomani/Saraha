﻿using System;
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
        public virtual UserProfile UserProfileFrom { get; set; }
        public int UserTo { get; set; }
        [ForeignKey("userTo")]
        public virtual UserProfile UserprofileFrom { get; set; }



    }
}
