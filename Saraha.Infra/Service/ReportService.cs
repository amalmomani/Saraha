using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;

namespace Saraha.Infra.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository repo;
        public ReportService(IReportRepository repo)
        {
            this.repo = repo;
        }
        public bool createReport(Report report)
        {
            return repo.createReport(report);
        }

        public bool deleteReport(int? id)
        {
            return repo.deleteReport(id);
        }

        public List<Report> getallReport()
        {
            return repo.getallReport();
        }

        public bool UpdateReport(Report report)
        {
            return repo.UpdateReport(report);
        }
    }
}
