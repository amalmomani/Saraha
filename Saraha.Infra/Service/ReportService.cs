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
        public void CreateReport(Report report)
        {
             repo.CreateReport(report);
        }

        public void DeleteReport(int? id)
        {
             repo.DeleteReport(id);
        }

        public List<Report> GetallReport()
        {
            return repo.GetallReport();
        }

        public void UpdateReport(Report report)
        {
             repo.UpdateReport(report);
        }
    }
}
