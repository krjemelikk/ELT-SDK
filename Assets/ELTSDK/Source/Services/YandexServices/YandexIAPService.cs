using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Extensions;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Services.YandexServices
{
   internal class YandexIAPService : SingletonBehaviour<YandexIAPService>, IIAPService
   {
      [DllImport("__Internal")]
      private static extern void LoadAllProductDataExtern();

      [DllImport("__Internal")]
      private static extern void PurchaseExtern(string productId, bool withConsume);

      [DllImport("__Internal")]
      private static extern void CheckPurchaseExtern(string productId, bool withConsume);

      [DllImport("__Internal")]
      private static extern void ConsumePurchaseExtern(string purchaseToken);


      private UniTaskCompletionSource<List<Product>> _loadCompletionSource;
      public Dictionary<string, Product> Products { get; private set; } = new();
      public Sprite CurrencySprite { get; private set; }
      public event Action<string> PurchaseComplete;

      public async UniTask LoadAllProductData()
      {
         _loadCompletionSource = new();
         LoadAllProductDataExtern();
         await _loadCompletionSource.Task;
         await LoadCurrencySprite();
      }

      public void Purchase(string productId, bool withConsume) =>
         PurchaseExtern(productId, withConsume);

      public void CheckPurchase(string productId, bool withConsume) =>
         CheckPurchaseExtern(productId, withConsume);
      
      private void OnProductDataLoaded(string json)
      {
         var products = JsonConvert.DeserializeObject<List<Product>>(json);
         Products = products.ToDictionary(p => p.Id, p => p);
         _loadCompletionSource.TrySetResult(products);
      }

      private void OnPurchaseComplete(string json)
      {
         var purchase = JsonConvert.DeserializeObject<Purchase>(json);
         PurchaseComplete?.Invoke(purchase.ProductId);

         if (purchase.WithConsume)
            ConsumePurchaseExtern(purchase.Token);
      }

      private async UniTask LoadCurrencySprite()
      {
         if (Products.Count >= 1)
         {
            var currencyTexture =
               await WebRequestService.Instance.DownloadTexture(Products.First().Value.CurrencyImageURL);
            CurrencySprite = currencyTexture.ToSprite();
         }
      }
   }
}