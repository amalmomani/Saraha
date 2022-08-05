using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
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
        public bool createReport(Report report)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Messagee", report.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@UserFromm", report.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", report.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Report_package_api.createReport", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool deleteReport(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ReportIDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Report_package_api.deleteReport", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Report> getallReport()
        {
            IEnumerable<Report> result = dbContext.Connection.Query<Report>("Report_package_api.getallReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateReport(Report report)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ReportIDD", report.ReportId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Messagee", report.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@UserFromm", report.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", report.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Report_package_api.UpdateReport", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
