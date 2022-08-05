﻿using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;

namespace Saraha.Core.Repository
{
    public interface IReportRepository
    {
        public List<Report> getallReport();
        public bool createReport(Report report);
        public bool UpdateReport(Report report);
        public bool deleteReport(int? id);
    }
}