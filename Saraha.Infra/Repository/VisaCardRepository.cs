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
        public ToasterDTO GetVisa(string card, DateTime Expir,int cost,int userId, int featureId)
        {
            ToasterDTO mess=new ToasterDTO();
            Userprofile User = new Userprofile();
            IEnumerable<VisaCard> result = dbContext.Connection.Query<VisaCard>("VisaApi_package.getallVisa", commandType: CommandType.StoredProcedure);
            IEnumerable<Userprofile> result2 = dbContext.Connection.Query<Userprofile>("User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
            var user = result2.Where(x => x.Userid == userId).FirstOrDefault();
            var cardd = result.Where(x => x.CardNumber == card).FirstOrDefault();
            if (user.Is_Premium ==true)
            {
                mess.message = "Sorry! You already have this service";
                return mess;
            }
            else 
            { 
                if (cardd != null)
                {
                    if (cardd.ExpirationDate == Expir && cardd.ExpirationDate >= DateTime.Today)
                    {
                        if (cardd.Balance >= cost)
                        {
                            UpdateVisa(cardd, cost);
                            mess.message = "Paid sucessfully";
                            CreatePurchase(cost, userId, featureId);
                            var p = new DynamicParameters();

                            p.Add("@UserIdd", user.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

                            p.Add("@IsPremiumm", 1, dbType: DbType.Int32, direction: ParameterDirection.Input);

                            var result3 = dbContext.Connection.ExecuteAsync("User_Package.UpdatePremium", p,
                                commandType: CommandType.StoredProcedure);
                            return mess;
                        }
                        else
                        {
                            mess.message = "Not enough balance";
                            return mess;
                        }
                    }
                    else
                    {
                        mess.message = "Sorry ! your card is expire!";
                        return mess;
                    }

                }

                else
                {
                    mess.message = "Invalid card number";
                    return mess;
                }
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
            parameter.Add("@datetoo",DateTime.Now.AddMonths((int)f.FeatureDuration), dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("@PurchaseCostt", cost, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@userIdd",u.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@featureIdd",f.FeatureId, dbType: DbType.Int32, direction: ParameterDirection.Input);



            var result3 = dbContext.Connection.Execute("Purchase_package.createPurchase", parameter, commandType: CommandType.StoredProcedure);

        }
    }
}
