using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Service
{
  public  interface IPurchaseService
    {
        public void CreatePurchase(Purchase purchase);

        public List<Purchase> GetAllPurchases();
        public void DeletePurchase(int id);
    }
}
