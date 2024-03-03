using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Source.SDK
{
   public class YandexSDKProducts : SingletonBehaviour<YandexSDKProducts>
   {
      [DllImport("__Internal")]
      private static extern string LoadProductDataExtern();

      public string CurrencyImageURL { get; private set; }
      public Dictionary<string, ProductData> Products { get; private set; }

      private bool _isLoaded;

      public IEnumerator LoadProductData()
      {
         LoadProductDataExtern();
         yield return new WaitUntil(() => _isLoaded);
      }

      private void OnProductDataLoaded(string data)
      {
         var dataJson = JsonUtility.FromJson<ProductDataJson>(data);
         CurrencyImageURL = dataJson.CurrencyImageURL;
         Products = dataJson.Products.ToDictionary(x => x.Id, x => x);

         _isLoaded = true;
      }
   }

   [Serializable]
   public class ProductDataJson
   {
      public string CurrencyImageURL;
      public List<ProductData> Products;
   }

   [Serializable]
   public class ProductData
   {
      public string Id;
      public string Tittle;
      public string Price;
      public string ProductImageURL;
   }
}