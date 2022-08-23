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
    public class LoginRepository : ILoginRepository
    {

        private readonly IDbcontext dbContext;
        public LoginRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateLogin(Login login)
        {
            var p = new DynamicParameters();

            p.Add("@UserNamee", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Passwordd", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserIdd", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@RoleIdd", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("Login_Package.CreateLogin", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool DeleteLogin(int? id)
        {
            var p = new DynamicParameters();

            p.Add("@LoginIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Login_Package.DeleteLogin", p,
                 commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Login> GetallLogins()
        {
            IEnumerable<Login> result = dbContext.Connection.Query<Login>("Login_Package.GetAllLogins",
                          commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool UpdateActiveStatus(int isActive, int loginId)
        {
            var p = new DynamicParameters();

            p.Add("@IsActive", isActive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@LoginIdd", loginId, dbType: DbType.Int32, direction: ParameterDirection.Input);
          

            var result = dbContext.Connection.ExecuteAsync("Login_Package.UpdateActiveStatus", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateBlockedStatus(int isBlocked, int loginId)
        {
            var p = new DynamicParameters();

            p.Add("@IsBlocked", isBlocked, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@LoginIdd", loginId, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.ExecuteAsync("Login_Package.UpdateBlockedStatus", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateLogin(Login login)
        {
            var p = new DynamicParameters();

            p.Add("@LoginIdd", login.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserNamee", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Passwordd", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserIdd", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@RoleIdd", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Login_Package.UpdateLogin", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateVerifyStatus(int isVerified, int loginId)
        {
            var p = new DynamicParameters();

            p.Add("@IsVerified", isVerified, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@LoginIdd", loginId, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.ExecuteAsync("Login_Package.UpdateVerifyStatus", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        public Login auth(Login  login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("UserNamee", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Passwordd", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Login> result = dbContext.Connection.Query<Login>("Login_Package.UserLogin", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Login GetLoginByUserId(int userId)
        {
            var p = new DynamicParameters();

            p.Add("@UserIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Login> result = dbContext.Connection.Query<Login>("Login_Package.GetLoginByUserId", p,
                 commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }

        public void ChangePassword(int loginId, string password)
        {
            var p = new DynamicParameters();

            p.Add("@LoginIdd", loginId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Passwordd", password, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Login_Package.ChangePassword", p,
                 commandType: CommandType.StoredProcedure);

        }
    }
}
