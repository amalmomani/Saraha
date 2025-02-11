﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.DTO;
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
        public List<Report> GetallReport()
        {

            return reportService.GetallReport();
        }
        [HttpPost]
        //[ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        public void CreateReport([FromBody] Report report)
        {
             reportService.CreateReport(report);
        }
        [HttpPost("SendEmail")]
        //[ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        public void SendEmail([FromBody] EmailReportedDTO user )
        {
            reportService.SendEmail(user.ReportedName,user.ReportMessage, user.ReportedEmail);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        public void UpdateReport([FromBody] Report report)
        {
             reportService.UpdateReport(report);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteReport(int? id)
        {
            reportService.DeleteReport(id);
        }
        [HttpGet("UserReport")]
        public List<UserReport> GetUserReport()
        {
            return reportService.GetUserReport();
        }
        //[HttpGet("ReportUser")]
        //public List<ReportUser> GetReportUser()
        //{
        //  //  return reportService.GetUserReport();
        //}
    }
}
