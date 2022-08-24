using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;
using Saraha.Core.DTO;

namespace Saraha.Core.Repository
{
    public interface IReportRepository
    {
        public List<Report> GetallReport();
        public void CreateReport(Report report);
        public void UpdateReport(Report report);
        public void DeleteReport(int? id);
        public List<UserReport> GetUserReport();
        public List<ReportUser> GetReportUser();

        public void SendEmail(string reportedname, string reportmsg, string reportedemail);

    }
}
