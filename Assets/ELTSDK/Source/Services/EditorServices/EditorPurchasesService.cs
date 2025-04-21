using System;
using ELTSDK.Source.Services.Interfaces;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorPurchasesService : IPurchaseService
   {
      public event Action<string> PurchaseComplete;

      public void Purchase(string id, bool withConsume)
      {
         PurchaseComplete?.Invoke(id);
      }

      public void CheckPurchase(string id, bool withConsume)
      {
         
      }
   }
}