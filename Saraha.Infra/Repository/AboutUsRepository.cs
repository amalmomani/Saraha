using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Infra.Repository
{
    public class AboutUsRepository : IAboutUsRepository
    {
        private readonly IDbcontext dbContext;

        public AboutUsRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
      

        public Aboutus GetAboutUs()
        {
            IEnumerable<Aboutus> result = dbContext.Connection.Query<Aboutus>("AboutUs_Package.GetAboutUs", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

      

        public void UpdateAboutUs(Aboutus aboutus)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@AboutUsIdd", aboutus.Aboutusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Titlee", aboutus.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Subtitlee", aboutus.Subtitle, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Imagepathh", aboutus.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Feature11", aboutus.Feature1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Feature22", aboutus.Feature2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Feature33", aboutus.Feature3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Feature1_Imagee", aboutus.Feature1_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Feature2_Imagee", aboutus.Feature2_Image, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Feature3_Imagee", aboutus.Feature3_Image, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("AboutUs_Package.UpdateAboutUs", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
