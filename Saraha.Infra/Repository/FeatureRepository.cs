﻿using Dapper;
using Microsoft.AspNetCore.Mvc;
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
  public  class FeatureRepository : IFeatureRepository
    {

        private readonly IDbcontext dbContext;

        public FeatureRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void DeleteFeature(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@featureIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Feature_package.deleteFeature", parameter, commandType: CommandType.StoredProcedure);

        }

        public List<Feature> GetAllFeatures()
        {
            IEnumerable<Feature> result = dbContext.Connection.Query<Feature>("Feature_package.getallFeatures", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateFeature(Feature feature)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@featureNamee", feature.FeatureName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@featurePricee", feature.FeaturePrice, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add("@featureDurationn", feature.FeatureDuration, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@ImagePathh", feature.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("@oldPricee", feature.OldPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("@featureDescribtionn", feature.FeatureDescribtion, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@videoLinkk", feature.VedioLink, dbType: DbType.String, direction: ParameterDirection.Input);





            var result = dbContext.Connection.Execute("Feature_package.createFeature", parameter, commandType: CommandType.StoredProcedure);
        }

        public void UpdateFeature(Feature feature)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@featureIdd", feature.FeatureId, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@featureNamee", feature.FeatureName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@featurePricee", feature.FeaturePrice, dbType: DbType.Double, direction: ParameterDirection.Input);
            parameter.Add("@featureDurationn", feature.FeatureDuration, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@ImagePathh", feature.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@oldPricee", feature.OldPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);

           // parameter.Add("@featureDescribtionn", feature.FeatureDescribtion, dbType: DbType.String, direction: ParameterDirection.Input);
           // parameter.Add("@videoLinkk", feature.VedioLink, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Feature_package.updateFeature", parameter, commandType: CommandType.StoredProcedure);
        }
        public List<FeatureSalesDTO> FeatureSales()
        {
            IEnumerable<FeatureSalesDTO> result = dbContext.Connection.Query<FeatureSalesDTO>("Feature_package.getFeatureSales", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<string> FeatureName()
        {
            IEnumerable<string> result = dbContext.Connection.Query<string>("featureName", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<int> FeatureTotalSales()
        {
            IEnumerable<int> result = dbContext.Connection.Query<int>("featureTotalSales", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public List<Charts> Chart()
        {
            IEnumerable<Charts> fea = dbContext.Connection.Query<Charts>("ServiceSales", commandType: CommandType.StoredProcedure);



            List<Charts> dataPoints = fea.ToList();
            //    dataPoints.Add(new Charts(item.StoreName, StoreProfit));



            //List<Charts> DataPoints = JsonConvert.SerializeObject(dataPoints);
            ////JsonConvert.SerializeObject(dataPoints);
            return dataPoints;
        }

    }
}
