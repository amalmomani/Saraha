using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;

namespace Saraha.Core.Repository
{
    public interface IReportRepository
    {
        public List<Report> GetallReport();
        public void CreateReport(Report report);
        public void UpdateReport(Report report);
        public void DeleteReport(int? id);
    }
}
