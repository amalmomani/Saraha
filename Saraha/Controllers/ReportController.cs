using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.Service;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;
        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Report>), StatusCodes.Status200OK)]
        public List<Report> getallReport()
        {

            return reportService.getallReport();
        }
        [HttpPost]
        //[ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        public bool createReport([FromBody] Report report)
        {
            return reportService.createReport(report);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        public bool UpdateReport([FromBody] Report report)
        {
            return reportService.UpdateReport(report);
        }

        [HttpDelete("delete/{id}")]
        public bool deleteReport(int? id)
        {
            return reportService.deleteReport(id);
        }

    }
}
