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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbcontext dbContext;
        public RoleRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateRole(Role role)
        {
            var p = new DynamicParameters();

            p.Add("@RoleNamee", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
          

            var result = dbContext.Connection.ExecuteAsync("Role_Package.CreateRole", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool DeleteRole(int? id)
        {
            var p = new DynamicParameters();

            p.Add("@RoleIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.ExecuteAsync("Role_Package.DeleteRole", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Role> GetallRoles()
        {
            IEnumerable<Role> result = dbContext.Connection.Query<Role>("Role_Package.GetAllRoles",
                          commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool UpdateRole(Role role)
        {
            var p = new DynamicParameters();

            p.Add("@RoleIdd", role.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@RoleNamee", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.Connection.ExecuteAsync("Role_Package.UpdateRole", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
