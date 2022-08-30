using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
    public interface IVisaCardServices
    {
        public List<VisaCard> GetallVisa();
        public void UpdateVisa(VisaCard visa);
    }
}
