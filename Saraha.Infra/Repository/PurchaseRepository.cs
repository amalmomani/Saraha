using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Saraha.Infra.Repository
{
   public class PurchaseRepository
    {
        private readonly IDbcontext dbContext;

        public PurchaseRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void CreatePurchase(Purchase purchase)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@dateFromm", purchase.Datefrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@datetoo", purchase.Dateto, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@PurchaseCostt", purchase.Purchasecost, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@userIdd", purchase.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@serviceIdd", purchase.Serviceid, dbType: DbType.Int32, direction: ParameterDirection.Input);



            var result = dbContext.Connection.Execute("Purchase_package.createLike", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Purchase> GetAllPurchases()
        {
            IEnumerable<Purchase> result = dbContext.Connection.Query<Purchase>("Purchase_package.getallPurchases", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public void DeletePurchase(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@purchaseIdd", id, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Purchase_package.deletePurchase", parameter, commandType: CommandType.StoredProcedure);
        }


    }
}
