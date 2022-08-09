﻿using Saraha.Core.Data;
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
        public void UpdateFeature(Feature feature, int id);
        public List<FeatureSalesDTO> FeatureSales();

    }
}