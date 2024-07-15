using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ELT_SDK.Source.Data;
using ELT_SDK.Source.Data.JSON;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Services;
using ELT_SDK.Source.Utilities;
using Newtonsoft.Json;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   internal class YandexSDKProducts : SingletonBehaviour<YandexSDKProducts>, IProductDataService
   {
      [DllImport("__Internal")]
      private static extern string LoadProductDataExtern();

      private Dictionary<string, ProductData> _products = new();
      private bool _isLoaded;

      public Texture CurrencyTexture { get; private set; }


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

         if (_products.FirstOrDefault().Value == null)
         {
            _isLoaded = true;
            return;
         }

         WebRequestService.Instance.DownloadImage(_products.FirstOrDefault().Value.CurrencyImageURL, SetTexture);
      }

      private void SetTexture(Texture texture)
      {
         CurrencyTexture = texture;
         _isLoaded = true;
      }
   }
}