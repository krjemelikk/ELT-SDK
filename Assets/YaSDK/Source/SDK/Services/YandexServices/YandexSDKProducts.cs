using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;
using YaSDK.Source.Data;
using YaSDK.Source.Data.JSON;
using YaSDK.Source.SDK.Services.Interfaces;

namespace YaSDK.Source.SDK.Services.YandexServices
{
   internal class YandexSDKProducts : SingletonBehaviour<YandexSDKProducts>, IProductDataService
   {
      [DllImport("__Internal")]
      private static extern string LoadProductDataExtern();

      private Dictionary<string, ProductData> _products = new();
      private bool _isLoaded;


      public IEnumerator LoadProductData()
      {
         LoadProductDataExtern();
         yield return new WaitUntil(() => _isLoaded);
      }

      public ProductData GetProduct(string id) =>
         _products.GetValueOrDefault(id);

      public List<ProductData> GetAllProducts() =>
         _products.Values.ToList();

      private void OnProductDataLoaded(string data)
      {
         var dataJson = JsonConvert.DeserializeObject<ProductCatalogJson>(data);
         _products = dataJson.Products.ToDictionary(x => x.Id, x => x);
         _isLoaded = true;
      }
   }
}