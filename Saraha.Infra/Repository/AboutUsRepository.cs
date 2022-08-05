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
        public void Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@AboutUsIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.Execute("AboutUs_Package.DeleteAboutUs", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Aboutus> GetAll()
        {
            IEnumerable<Aboutus> result = dbContext.Connection.Query<Aboutus>("AboutUs_Package.GetAllAboutUs", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void Insert(Aboutus aboutus)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Titlee", aboutus.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Subtitlee", aboutus.Subtitle, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Imagepathh", aboutus.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
          
            var result = dbContext.Connection.Execute("AboutUs_Package.CreateAboutUs", parameter, commandType: CommandType.StoredProcedure);
        }

        public void Update(Aboutus aboutus)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@AboutUsIdd", aboutus.Aboutusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Titlee", aboutus.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Subtitlee", aboutus.Subtitle, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Imagepathh", aboutus.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("AboutUs_Package.UpdateAboutUs", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
