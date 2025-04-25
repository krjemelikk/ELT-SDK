using System;
using ELTSDK.Source.Services.Interfaces;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class PurchaseServiceLogger : IPurchaseService
   {
      private const string Label = "<color=yellow><b>[Purchase Service]</b></color>";
      private readonly IPurchaseService _service;

      public PurchaseServiceLogger(IPurchaseService service) =>
         _service = service;

      public event Action<string> PurchaseComplete
      {
         add => _service.PurchaseComplete += value;
         remove => _service.PurchaseComplete -= value;
      }

      public void Purchase(string productId, bool withConsume)
      {
         _service.Purchase(productId, withConsume);
         Debug.Log($"{Label} - Purchase request with Id: {productId}, Consume: {withConsume}");
      }

      public void CheckPurchase(string productId, bool withConsume)
      {
         _service.CheckPurchase(productId, withConsume);
         Debug.Log($"{Label} - Check Purchase Request with Id:{productId}, Consume:{withConsume}");
      }
   }
}