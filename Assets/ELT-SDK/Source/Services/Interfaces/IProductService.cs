using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELT_SDK.Source.Entities;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface IProductService
   {
      Dictionary<string, Product> Products { get; }
      Sprite CurrencySprite { get; }
      UniTask LoadAllProductData();
   }
}