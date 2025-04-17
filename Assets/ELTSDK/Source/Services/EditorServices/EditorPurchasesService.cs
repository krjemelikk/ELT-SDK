using System;
using ELTSDK.Source.Extensions;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities.Enum;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
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