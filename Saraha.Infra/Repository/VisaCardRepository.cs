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
    public class VisaCardRepository : IVisaCardRepository
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
        public void UpdateVisa(VisaCard visa, int cost)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@cardNum", visa.CardNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@priceOfService", cost , dbType: DbType.String, direction: ParameterDirection.Input);
            //parameter.Add("@UserIDD", activity.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //parameter.Add("@LikeIDD", activity.LikeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //parameter.Add("@CommentIDD", activity.CommentId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("VisaApi_package.VisaUpdate", parameter, commandType: CommandType.StoredProcedure);

        }
        public string GetVisa(string card, int cost,int userId, int featureId)
        {
            var message="";
            IEnumerable<VisaCard> result = dbContext.Connection.Query<VisaCard>("VisaApi_package.getallVisa", commandType: CommandType.StoredProcedure);

            var cardd = result.Where(x => x.CardNumber == card).FirstOrDefault();
            if (cardd != null)
            {
                if (cardd.Balance >= cost)
                {
                    UpdateVisa(cardd, cost);
                    message = "Paid sucessfully";
                    CreatePurchase(cost, userId, featureId);
                    return message;
                }
                else
                {
                    message = "Not enough balance";
                    return message;
                }
            }
            else {
                message = "Invalid card number";
            return message; 
            }
        }



        public void CreatePurchase(int cost , int userId, int featureId)
        {
            IEnumerable<Feature> result = dbContext.Connection.Query<Feature>("Feature_package.getallFeatures", commandType: CommandType.StoredProcedure);
            var f = result.Where(x => x.FeatureId == featureId).FirstOrDefault();

            IEnumerable<Userprofile> result2 = dbContext.Connection.Query<Userprofile>("User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
            var u = result2.Where(x=>x.Userid==userId).FirstOrDefault();


            var parameter = new DynamicParameters();
            parameter.Add("@dateFromm", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@datetoo",DateTime.Now.AddDays((int)f.FeatureDuration), dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@PurchaseCostt", cost, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@userIdd",u.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@featureIdd",f.FeatureId, dbType: DbType.Int32, direction: ParameterDirection.Input);



            var result3 = dbContext.Connection.Execute("Purchase_package.createPurchase", parameter, commandType: CommandType.StoredProcedure);

        }
    }
}
