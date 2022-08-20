using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
  public class ReportDetailsDTO
    {
        public int ReportId { set; get; }

        public int ReporterId { set; get; }
        public string ReporterName { set; get; }
        public string ReporterEmail { set; get; }
        public string Report { set; get; }
        public string ReportedName { set; get; }
        public string ReportedEmail { set; get; }
        public int ReportedId { set; get; }
    }
}
