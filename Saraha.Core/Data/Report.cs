using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Saraha.Core.Data
{
   public  class Report
    {
        [Key]
        public int ReportId { get; set; }
        public string Message { get; set; }
        public int UserFrom { get; set; }
       
        public int UserTo { get; set; }
        public int ReportCount { get; set; }
    }
}
