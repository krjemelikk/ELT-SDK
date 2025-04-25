using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using UnityEngine;

namespace ELTSDK.Source.Services.Interfaces
{
   public interface IIAPService
   {
      Dictionary<string, Product> Products { get; }
      Sprite CurrencySprite { get; }
      event Action<string> PurchaseComplete;
      UniTask LoadAllProductData();
      void Purchase(string productId, bool withConsume);
      void CheckPurchase(string productId, bool withConsume);
   }
}