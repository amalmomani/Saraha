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
    public class HomeRepository : IHomeRepository
    {
        private readonly IDbcontext dbContext;

        public HomeRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Homeidd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Home_Package.deleteHome", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Home> getall()
        {
            IEnumerable<Home> result = dbContext.Connection.Query<Home>("Home_Package.getallHome", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void insert(Home home)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Homeidd", home.Homeid, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Logoo", home.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Backgroundd", home.Background, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Textt", home.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Aboutusidd", home.Aboutusid, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Contactusidd", home.Contactusid, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Home_Package.createHome", parameter, commandType: CommandType.StoredProcedure);

        }

        public void update(Home home)
        {
 var parameter = new DynamicParameters();
            parameter.Add("@Homeidd", home.Homeid, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Logoo", home.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Backgroundd", home.Background, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Textt", home.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Aboutusidd", home.Aboutusid, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Contactusidd", home.Contactusid, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Home_Package.UpdateHome", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
