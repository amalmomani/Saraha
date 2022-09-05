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
    public class EventRepository:IEventRepository
    {
        private readonly IDbcontext dbContext;

        public EventRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Insert(Event e)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idd", e.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@headerr", e.header, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@typee", e.type, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@descriptionn", e.description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@pricee", e.price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@text11", e.text1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@text22", e.text2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@text33", e.text3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@locationn", e.location, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@eventDatee", DateTime.Now, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Event_package.createprocedure", parameter, commandType: CommandType.StoredProcedure);

        }
        public void Update(Event e)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idd", e.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@headerr", e.header, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@typee", e.type, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@descriptionn", e.description, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@pricee", e.price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@text11", e.text1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@text22", e.text2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@text33", e.text3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@locationn", e.location, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@eventDatee", DateTime.Now, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Event_package.Updateprocedure", parameter, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@idd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Event_package.deleteprocedure", parameter, commandType: CommandType.StoredProcedure);
        }

        public List<Event> GetAll()
        {
            IEnumerable<Event> result = dbContext.Connection.Query<Event>("Event_package.getall", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
