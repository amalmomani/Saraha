﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Saraha.Core.Data
{
   public  class Report
    {
        [Key]
        public int reportID { get; set; }
        public string message { get; set; }
        public int userFrom { get; set; }
       
        public int userTo { get; set; }
    }
}