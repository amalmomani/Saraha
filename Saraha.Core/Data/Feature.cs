using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Data
{
  public class Feature
    {
        public decimal FeatureId { get; set; }
        public string FeatureName { get; set; }
        public decimal? FeaturePrice { get; set; }
        public decimal? FeatureDuration { get; set; }
        public string ImagePath { get; set; }
    }
}
