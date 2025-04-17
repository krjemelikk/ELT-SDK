using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using UnityEngine;

namespace ELTSDK.Source.Services.Interfaces
{
   public interface IProductService
   {
      Dictionary<string, Product> Products { get; }
      Sprite CurrencySprite { get; }
      UniTask LoadAllProductData();
   }
}