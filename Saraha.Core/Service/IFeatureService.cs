using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
  public interface IFeatureService
    {
        public void DeleteFeature(int id);

        public List<Feature> GetAllFeatures();
        public void CreateFeature(Feature feature);
        public void UpdateFeature(Feature feature);
        public List<FeatureSalesDTO> FeatureSales();
        public List<Charts> Chart();
        public List<string> FeatureName();



        public List<int> FeatureTotalSales();
       

    }
}
