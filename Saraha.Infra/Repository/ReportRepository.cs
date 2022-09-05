using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Dapper;
using MimeKit;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Repository;

namespace Saraha.Infra.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDbcontext dbContext;

        public ReportRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateReport(Report report)
        {
            //IEnumerable<Report> reports = dbContext.Connection.Query<Report>("Report_package_api.getallReport", commandType: CommandType.StoredProcedure);
            //bool exist = reports.Any(r => r.UserFrom == report.UserFrom && r.UserTo == report.UserTo);
            //IEnumerable<ReportDetailsDTO> reportdetails = dbContext.Connection.Query<ReportDetailsDTO>("Report_package_api.getReportsDetails", commandType: CommandType.StoredProcedure);
            //var details = reportdetails.Where(r => r.ReporterId == report.UserFrom && r.ReportedId == report.UserTo).SingleOrDefault();

            //if (exist)
            //{
            //    var parameter1 = new DynamicParameters();

            //    parameter1.Add("@ReportIDD", details.ReportId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //    dbContext.Connection.Execute("Report_package_api.updateReportCount", parameter1, commandType: CommandType.StoredProcedure);
            //    SendEmail(details.ReportedName, details.Report, details.ReportedEmail);
               
           
            //}

            //else
            //{
                var parameter = new DynamicParameters();

                parameter.Add("@Messagee", report.Message, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("@UserFromm", report.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("@UserToo", report.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.Connection.Execute("Report_package_api.createReport", parameter, commandType: CommandType.StoredProcedure);
                //SendEmail(details.ReportedName, details.Report, details.ReportedEmail);

              
            //}
           
        }

        public void DeleteReport(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ReportIDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Report_package_api.deleteReport", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Report> GetallReport()
        {
            IEnumerable<Report> result = dbContext.Connection.Query<Report>("Report_package_api.getallReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateReport(Report report)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ReportIDD", report.ReportId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Messagee", report.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@UserFromm", report.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", report.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Report_package_api.UpdateReport", parameter, commandType: CommandType.StoredProcedure);
 
        }


          public void SendEmail(string reportedname ,string reportmsg , string reportedemail)
        {
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587); //587
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("waedshareaa@outlook.com", "W@edW@ed12");

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            MailMessage mail = new MailMessage();
            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            //mail.Body = builder.ToMessageBody();
           
//            mail.Body = "<!DOCTYPE html>" +
//                  "<html> " +
//                     "<body style=\"margin-top: 20px;\"> " +
//                     "<table class=\"body - wrap\" style=\"font-family:'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; width: 100 %; background - color: #f6f6f6; margin: 0;\" bgcolor=\"#f6f6f6;\">" +
//                     "<tbody>" +
//                     "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
//                     "<td style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; vertical - align: top; margin: 0; \" valign=\"top\">" + "</td>" +
//                     "<td class=\"container\"width=\"600\"style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; display: block!important; max - width: 600px!important; clear: both!important; margin: 0 auto; \" valign=\"top\">" +
//                     "<div class=\"content\"style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; max - width: 600px; display: block; margin: 0 auto; padding: 20px; \">" +
//                     "<table class=\"main\"width=\"100 %\" cellpadding=\"0\"cellspacing=\"0\" itemprop=\"action\" itemtype=\"http://schema.org/ConfirmAction \"style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-b;\">" +
//                     "<tbody>" +
//                     "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0;\">" +
//                     "<td class=\"content - wrap\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; vertical - align: top; margin: 0; padding: 30px; border: 3px solid #67a8e4;border-radius: 7px; background-color: #fff;\" valign=\"top\">" +
//                     "<meta itemprop=\"name\" content=\"Confirm Email\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
//                     "<table width=\"100 % \"cellpadding=\"0\" cellspacing=\"0\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
//                     "<tbody>" +
//                     "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
//                     "<td class=\"content - block\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; vertical - align: top; margin: 0; padding: 0 0 20px; \" valign=\"top\">" +
//                     "Hi " + "<b>" + "waed!!" + "</b>" + " hope you doing well :)" +
//                     "</td>" +
//                     "</tr>" +
//                     "<tr style=\"font-family:\'HelveticaNeue\',Helvetica,Arial,sans - serif; box - sizing:border - box; font-size:14px;margin: 0;\">" +
//                     " <td class=\"content - block\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; vertical - align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">" +
//                     "Please note that you have been reported as: " + "<b>" + "waed!!" + "</b>" + "</br>" + "Repeating such actions in Saraha community may result in the permanent deletion of your account." +
//                     "</td>" +
//                     "</tr>" +
//                     "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans - serif; box - sizing: border - box; font - size: 14px; margin: 0; \">" +
//                     "<td class=\"content-block\" itemprop=\"handler\" itemscope=\"\" itemtype=\"http://schema.org/HttpActionHandler \" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">" +
//                     " <a href=\"https://www.youtube.com/watch?v=Khpzs-7WWeA \" class=\"btn-primary\" itemprop=\"url\" style=\"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; color: #FFF; text-decoration: none; line-height: 2em; font-weight: bold; text-align: center; cursor: pointer; display: inline-block; border-radius: 5px; text-transform: capitalize; background-color: #f06292; margin: 0; border-color: #f06292; border-style: solid; border-width: 8px 16px;\">" +
//                     "It's Okay" + "\n" + "No problem ? :)" + "</a>" + "</td>" + " </tr>" +
//                    "<tr style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\" >" +
//                    "<td class=\"content-block\" style=\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0 0 20px;\" valign=\"top\">" +
//                      "<b>" + "Saraha Live Website" + "</b>" +
//                      " <p>" + "Support Team" + "</p>" +
//                     "</td>" +
//                      "</tr>" +
//                      "<tr style =\"font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;\" >" +
//                      "<td class=\"content-block\" style=\"text-align: center;font-family:\'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 0;\" valign=\"top\">" +
//                      "</td>" +
//                     "</tr>" +
//                     " </tbody >" +
//                      "</table >" +
//                       "</td>" +
//                                "</tr >" +
//                            "</tbody >" +
//                        "</table >" +
//                    "</div>" +
//                "</td>" +
//            "</tr>" +
//        "</tbody >" +
//   " </table>" +
//  " </body>" +
//"</html>";

            mail.Subject = "Report Notifcation";
            mail.Body = reportmsg;
            mail.From = new MailAddress("waedshareaa@outlook.com", "Saraha Time-no-reply");
            mail.To.Add(new MailAddress(reportedemail, reportedname ));
            smtpClient.Send(mail);


            //            message.From.Add(from);
            //            message.To.Add(to);


            //            using (var item = new MailKit.Net.Smtp.SmtpClient())
            //            {
            //                item.Connect("smtp.live.com", 587, false );
            //                item.Authenticate("waedshareaa@outlook.com", "W@edW@ed12");
            //                item.Send(message);
            //                item.Disconnect(true);
            //            }


        }

        public List<UserReport> GetUserReport()
        {

            IEnumerable<UserReport> result = dbContext.Connection.Query<UserReport>("GetUserReport.UserReport", commandType: CommandType.StoredProcedure);
            List<UserReport> R = result.ToList();
            return R;

        }
        public List<ReportUser> GetReportUser()
        {
            IEnumerable<ReportUser> result = dbContext.Connection.Query<ReportUser>("DTOPackage.ReportUser", commandType: CommandType.StoredProcedure);
            List<ReportUser> R = result.ToList();
            return R;
        }


    }
}
