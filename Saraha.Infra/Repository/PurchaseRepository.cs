using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Saraha.Infra.Repository
{
   public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IDbcontext dbContext;

        public PurchaseRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void CreatePurchase(Purchase purchase)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@dateFromm", purchase.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@datetoo", purchase.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@PurchaseCostt", purchase.PurchaseCost, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@userIdd", purchase.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@featureIdd", purchase.FeatureId, dbType: DbType.Int32, direction: ParameterDirection.Input);



            var result = dbContext.Connection.Execute("Purchase_package.createPurchase", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Purchase> GetAllPurchases()
        {
            IEnumerable<Purchase> result = dbContext.Connection.Query<Purchase>("Purchase_package.getallPurchases", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public void DeletePurchase(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@purchaseIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Purchase_package.deletePurchase", parameter, commandType: CommandType.StoredProcedure);
        }
        public List<OrderAndAerviceDTO> GetOrders()
        {

            IEnumerable<OrderAndAerviceDTO> result = dbContext.Connection.Query<OrderAndAerviceDTO>("GetOrderService.GetOrders", commandType: CommandType.StoredProcedure);
            List<OrderAndAerviceDTO> R = result.ToList();
         
            return R;
        }

     
    }
}
