using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Extensions;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorIAPService : IIAPService
   {
      private const string ProductsCsvPath = "products";
      private const string CurrencyURL =
         "//yastatic.net/s3/games-static/static-data/images/payments/sdk/currency-icon-s@2x.png";

      public Dictionary<string, Product> Products { get; private set; } = new();
      public Sprite CurrencySprite { get; private set; }
      public event Action<string> PurchaseComplete;

      public async UniTask LoadAllProductData()
      {
         var csv = Resources.Load<TextAsset>(ProductsCsvPath).text;
         Products = ConvertCsv(csv);

         await LoadCurrencySprite();
      }

      public void Purchase(string id, bool withConsume) =>
         PurchaseComplete?.Invoke(id);

      public void CheckPurchase(string id, bool withConsume) { }

      private async UniTask LoadCurrencySprite()
      {
         if (Products.Count >= 1)
         {
            var currencyTexture =
               await WebRequestService.Instance.DownloadTexture(Products.First().Value.CurrencyImageURL);
            CurrencySprite = currencyTexture.ToSprite();
         }
      }

      private Dictionary<string, Product> ConvertCsv(string csv)
      {
         var products = new Dictionary<string, Product>();
         var raws = csv.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
         
         for (int i = 1; i < raws.Count; i++)
         {
            var line = raws[i].Trim();
            var columns = line.Split(';');
            
            var temp = new
            {
               Id = columns[0],
               Price = columns[1],
               Title = columns[2],
               Description = columns[3],
               CurrencyImageURL = CurrencyURL
            };
            
            var tempJson = JsonConvert.SerializeObject(temp);
            var product = JsonConvert.DeserializeObject<Product>(tempJson);
            
            products.Add(product.Id, product);
         }

         return products;
      }
   }
}