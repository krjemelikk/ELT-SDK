using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class ProductServiceLogger : IProductService
   {
      private const string Label = "<color=yellow><b>[Product Service]</b></color>";
      private readonly IProductService _service;

      public ProductServiceLogger(IProductService service) =>
         _service = service;

      public Dictionary<string, Product> Products => _service.Products;
      public Sprite CurrencySprite => _service.CurrencySprite;
      
      public async UniTask LoadAllProductData()
      {
         await _service.LoadAllProductData();
         Debug.Log($"{Label} - Products data loaded: \n {JsonConvert.SerializeObject(Products, Formatting.Indented)}");
      }
   }
}