using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.Repository;

namespace Saraha.Infra.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDbcontext dbContext;

        public MessageRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool createMessage(Message message)
        {
            var parameter = new DynamicParameters();
        
            parameter.Add("@MessageContentt", message.MessageContent, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@statuss", message.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@MessageDatee", message.MessageDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@UserFromm", message.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", message.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Message_package_api.createMessage", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool deleteMessage(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@MessageIDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Message_package_api.deleteMessage", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Message> getallMessage()
        {
            IEnumerable<Message> result = dbContext.Connection.Query<Message>("Message_package_api.getallMessage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateMessage(Message message)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@MessageIDD", message.MessageID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@MessageContentt", message.MessageContent, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@statuss", message.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@MessageDatee", message.MessageDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@UserFromm", message.UserFrom, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@UserToo", message.UserTo, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Message_package_api.UpdateMessage", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
