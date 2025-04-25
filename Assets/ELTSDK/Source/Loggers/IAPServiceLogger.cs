using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class IAPServiceLogger : IIAPService
   {
      private const string Label = "<color=yellow><b>[IAP Service]</b></color>";
      private readonly IIAPService _service;

      public IAPServiceLogger(IIAPService service) =>
         _service = service;

      public Dictionary<string, Product> Products => _service.Products;
      public Sprite CurrencySprite => _service.CurrencySprite;

      public event Action<string> PurchaseComplete
      {
         add => _service.PurchaseComplete += value;
         remove => _service.PurchaseComplete -= value;
      }

      public async UniTask LoadAllProductData()
      {
         await _service.LoadAllProductData();
         Debug.Log($"{Label} - Products data loaded: \n {JsonConvert.SerializeObject(Products, Formatting.Indented)}");
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