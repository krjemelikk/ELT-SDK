using System;
using System.Runtime.InteropServices;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities;
using Newtonsoft.Json;

namespace ELTSDK.Source.Services.YandexServices
{
   internal class YandexPurchaseService : SingletonBehaviour<YandexPurchaseService>, IPurchaseService
   {
      [DllImport("__Internal")]
      private static extern void PurchaseExtern(string productId, bool withConsume);
      
      [DllImport("__Internal")]
      private static extern void CheckPurchaseExtern(string productId, bool withConsume);
     
      [DllImport("__Internal")]
      private static extern void ConsumePurchaseExtern(string purchaseToken);
      
      public event Action<string> PurchaseComplete;
      
      public void Purchase(string productId, bool withConsume)
      {
         PurchaseExtern(productId, withConsume);
      }

      public void CheckPurchase(string productId, bool withConsume)
      {
         CheckPurchaseExtern(productId, withConsume);
      }

      private void OnPurchaseComplete(string json)
      {
         var purchase = JsonConvert.DeserializeObject<Purchase>(json);
         PurchaseComplete?.Invoke(purchase.ProductId);
         
         if (purchase.WithConsume)
            ConsumePurchaseExtern(purchase.Token);
      }
   }
}