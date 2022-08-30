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
        public void CreateActivity(Activity activity)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Messagee", activity.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@UserIDD", activity.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@LikeIDD", activity.LikeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@CommentIDD", activity.CommentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@PostIDD", activity.PostId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Activity_package_api.createActivity", parameter, commandType: CommandType.StoredProcedure);
           
        }

        public void DeleteActivity(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ActivityIDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Activity_package_api.deleteActivity", parameter, commandType: CommandType.StoredProcedure);

          
        }

        public List<Activity> GetActivityByUserId(int userId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UserIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Activity> result = dbContext.Connection.Query<Activity>
                ("Activity_package_api.GetActivityByUserId",parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Activity> GetallActivity()
        {
            IEnumerable<Activity> result = dbContext.Connection.Query<Activity>("Activity_package_api.getallActivity", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateActivity(Activity activity)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ActivityIDD", activity.ActivityID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Messagee", activity.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@UserIDD", activity.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@LikeIDD", activity.LikeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@CommentIDD", activity.CommentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@PostIDD", activity.PostId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@ActivityDatee", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Activity_package_api.UpdateActivity", parameter, commandType: CommandType.StoredProcedure);
      
        }
    }
}
