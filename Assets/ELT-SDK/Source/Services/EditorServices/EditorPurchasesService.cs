using System;
using ELT_SDK.Source.Extensions;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities.Enum;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices
{
   internal class EditorPurchasesService : IPurchaseService
   {
      public event Action<string> PurchaseComplete;

      public void Purchase(string id, bool withConsume)
      {
         Debug.Log($"{"ELTSDK".WithColor(TextColor.Yellow)} - Purchase");
         PurchaseComplete?.Invoke(id);
      }

      public void CheckPurchase(string id, bool withConsume)
      {
         Debug.Log($"{"ELTSDK".WithColor(TextColor.Yellow)} - Check Purchase");
      }
   }
}