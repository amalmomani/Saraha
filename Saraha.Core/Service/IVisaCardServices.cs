using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
    public interface IVisaCardServices
    {
        public List<VisaCard> GetallVisa();
        public void UpdateVisa(VisaCard visa, int cost);
        public ToasterDTO GetVisa(string card, int cost, int userId, int featureId);
        
        }
}
