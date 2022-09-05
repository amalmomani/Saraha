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
    public class AddsRepository:IAddsRepository
    {
        private readonly IDbcontext dbContext;

        public AddsRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Insert(Adds adds)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idd", adds.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@namee", adds.name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@pricee", adds.price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Imagepathh", adds.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@discountt", adds.discount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@addsDatee", adds.addsDate, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("adds_package.createprocedure", parameter, commandType: CommandType.StoredProcedure);

        }
        public void Update(Adds adds)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idd", adds.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@namee", adds.name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@pricee", adds.price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Imagepathh", adds.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@discountt", adds.discount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@addsDatee", adds.addsDate, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("adds_package.Updateprocedure", parameter, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("adds_package.deleteprocedure", parameter, commandType: CommandType.StoredProcedure);
        }

        public List<Adds> GetAll()
        {
            IEnumerable<Adds> result = dbContext.Connection.Query<Adds>("adds_package.getall", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
