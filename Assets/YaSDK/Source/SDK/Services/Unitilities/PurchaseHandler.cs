using YaSDK.Source.SDK.Services.Interfaces;

namespace YaSDK.Source.SDK.Services
{
   public class PurchaseHandler : IPurchaseHandler
   {
      private readonly IPurchaseService _purchaseService;

      public PurchaseHandler(IPurchaseService purchaseService)
      {
         _purchaseService = purchaseService;
      }
      
      public void Initialize() =>
         Subscribe();

      public void CleanUp() =>
         Unsubscribe();

      private void Subscribe() =>
         _purchaseService.PurchaseComplete += OnPurchaseComplete;

      private void Unsubscribe() =>
         _purchaseService.PurchaseComplete -= OnPurchaseComplete;

      private void OnPurchaseComplete(string productId)
      {
         switch (productId)
         {
            // purchase processing depending on ID
         }
      }
   }
}