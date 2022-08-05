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
    public class ActivityRepository : IActivityRepository
    {
        private readonly IDbcontext dbContext;

        public ActivityRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool createActivity(Activity activity)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Messagee", activity.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@UserIDD", activity.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@LikeIDD", activity.LikeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@CommentIDD", activity.CommentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@PostIDD", activity.PostId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Activity_package_api.createActivity", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool deleteActivity(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ActivityIDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Activity_package_api.deleteActivity", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Activity> getallActivity()
        {
            IEnumerable<Activity> result = dbContext.Connection.Query<Activity>("Activity_package_api.getallActivity", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateActivity(Activity activity)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ActivityIDD", activity.ActivityID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Messagee", activity.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@UserIDD", activity.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@LikeIDD", activity.LikeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@CommentIDD", activity.CommentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@PostIDD", activity.PostId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Activity_package_api.UpdateActivity", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
