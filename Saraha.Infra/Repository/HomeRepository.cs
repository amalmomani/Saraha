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
       

        public Home GetHome()
        {
            IEnumerable<Home> result = dbContext.Connection.Query<Home>("Home_Package.GetHome", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

    

        public void UpdateHome(Home home)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@HomeIdd", home.Homeid, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Logoo", home.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Slider11", home.Slider1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Slider22", home.Slider2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Description11", home.Description1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Description22", home.Description2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Emaill", home.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@PhoneNumberr", home.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Addresss", home.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Member1_Namee", home.Member1_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Member2_Namee", home.Member2_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Member3_Namee", home.Member3_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Member4_Namee", home.Member4_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Member1_Imagee", home.Member1_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Member2_Imagee", home.Member2_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Member3_Imagee", home.Member3_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Member4_Imagee", home.Member4_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            
            var result = dbContext.Connection.Execute("Home_Package.UpdateHome", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
