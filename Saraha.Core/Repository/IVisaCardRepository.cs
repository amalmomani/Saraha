using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
   public interface IVisaCardRepository
    {
        public List<VisaCard> GetallVisa();
        public void UpdateVisa(VisaCard visa, int cost);
        public string GetVisa(string card, int cost);
        
        }
}
