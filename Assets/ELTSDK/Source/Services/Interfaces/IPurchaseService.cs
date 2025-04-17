using System;

namespace ELTSDK.Source.Services.Interfaces
{
   public interface IPurchaseService
   {
      event Action<string> PurchaseComplete;
      void Purchase(string productId, bool withConsume);
      void CheckPurchase(string productId, bool withConsume);
   }
}