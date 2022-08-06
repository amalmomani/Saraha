using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
  public  interface IPurchaseService
    {
        public void CreatePurchase(Purchase purchase);

        public List<Purchase> GetAllPurchases();
        public void DeletePurchase(int id);
    }
}
