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
    public class ContactusRepository : IContactusRepository
    {
        private readonly IDbcontext dbContext;

        public ContactusRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ContactUsidd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("ContactUs_Package.deleteContactUs", parameter, commandType: CommandType.StoredProcedure);
        }

        public List<Contactus> GetAll()
        {
            IEnumerable<Contactus> result = dbContext.Connection.Query<Contactus>("ContactUs_Package.getallContactUs", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void Insert(Contactus contactus)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ContactUsidd", contactus.Contactusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserNamee", contactus.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Emaill", contactus.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Messagee", contactus.Message, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("ContactUs_Package.createContactUs", parameter, commandType: CommandType.StoredProcedure);

        }
        public void Update(Contactus contactus)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ContactUsidd", contactus.Contactusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserNamee", contactus.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Emaill", contactus.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Messagee", contactus.Message, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("ContactUs_Package.UpdateContactUs", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
