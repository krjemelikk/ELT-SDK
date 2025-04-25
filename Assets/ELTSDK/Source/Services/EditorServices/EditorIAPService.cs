using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Extensions;
using ELTSDK.Source.Services.Interfaces;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorIAPService : IIAPService
   {
      private const string EditorProductPath = "products";
      public Dictionary<string, Product> Products { get; private set; } = new();
      public Sprite CurrencySprite { get; private set; }
      public event Action<string> PurchaseComplete;

      public async UniTask LoadAllProductData()
      {
         var json = Resources.Load<TextAsset>(EditorProductPath).text;
         var products = JsonConvert.DeserializeObject<List<Product>>(json);
         Products = products.ToDictionary(x => x.Id, x => x);

         await LoadCurrencySprite();
      }

      public void Purchase(string id, bool withConsume) =>
         PurchaseComplete?.Invoke(id);

      public void CheckPurchase(string id, bool withConsume)
      {
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