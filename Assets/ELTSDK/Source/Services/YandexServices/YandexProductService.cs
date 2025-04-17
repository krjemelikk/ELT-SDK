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
   internal class YandexProductService : SingletonBehaviour<YandexProductService>, IProductService
   {
      [DllImport("__Internal")]
      private static extern void LoadAllProductDataExtern();

      private UniTaskCompletionSource<List<Product>> _loadCompletionSource;
      public Dictionary<string, Product> Products { get; private set; } = new();
      public Sprite CurrencySprite { get; private set; }

      public async UniTask LoadAllProductData()
      {
         _loadCompletionSource = new();
         LoadAllProductDataExtern();
         await _loadCompletionSource.Task;
         await LoadCurrencySprite();
      }

      private void OnProductDataLoaded(string json)
      {
         var products = JsonConvert.DeserializeObject<List<Product>>(json);
         Products = products.ToDictionary(p => p.Id, p => p);
         _loadCompletionSource.TrySetResult(products);
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