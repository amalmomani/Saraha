using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Saraha.Infra.Repository
{
    public class FollowRepository : IFollowRepository
    {
        private readonly IDbcontext dbContext;

        public FollowRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateFollow(Follow follow)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserFromm", follow.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", follow.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@FollowDatee", follow.FollowDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.Execute("Follow_Package.CreateFollow", parameter, commandType: CommandType.StoredProcedure);

        }

        public void DeleteFollow(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Idd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
         
            var result = dbContext.Connection.Execute("Follow_Package.DeleteFollow", parameter, commandType: CommandType.StoredProcedure);
        }

        public void DeleteFollowByUser(int userFrom, int userTo)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserFromm", userFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", userTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Follow_Package.DeleteFollowByUser",
                parameter, commandType: CommandType.StoredProcedure);
        }

        public List<Follow> GetAll()
        {
           
            IEnumerable<Follow> result = dbContext.Connection.Query<Follow>("Follow_Package.GetAll", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Userprofile> GetFollowers(int userTo)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserToo", userTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("Follow_Package.GetFollowers",
                parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Userprofile> GetFollowing(int userFrom)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserFromm", userFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("Follow_Package.GetFollowing",
                parameter, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool IsFollow(int userFrom, int userTo)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserFromm", userFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", userTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            int result = dbContext.Connection.QuerySingleOrDefault<int>("Follow_Package.IsFollow", 
                parameter, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public void UpdateBlockStatus(int id, int isBlock)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Idd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@IsBlockk", isBlock, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Follow_Package.UpdateBlockStatus", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
