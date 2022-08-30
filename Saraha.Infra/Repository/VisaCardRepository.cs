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
   public class VisaCardRepository: IVisaCardRepository
    {
        private readonly IDbcontext dbContext;

        public VisaCardRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<VisaCard> GetallVisa()
        {
            IEnumerable<VisaCard> result = dbContext.Connection.Query<VisaCard>("VisaApi_package.getallVisa", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public void UpdateVisa(VisaCard visa)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@cardNum", visa.CardNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@priceOfService", visa.Balance, dbType: DbType.String, direction: ParameterDirection.Input);
            //parameter.Add("@UserIDD", activity.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //parameter.Add("@LikeIDD", activity.LikeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //parameter.Add("@CommentIDD", activity.CommentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            var result = dbContext.Connection.ExecuteAsync("VisaApi_package.VisaUpdate", parameter, commandType: CommandType.StoredProcedure);

        }
    }
}
