using System;
using ELTSDK.Source.Extensions;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities.Enum;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorAdvertisementService : IAdvertisementService
   {
      public event Action AdOpen;
      public event Action AdClose;
      
      public void ShowInterstitial()
      {
         Debug.Log($"[{"ELTSDK".WithColor(TextColor.Yellow)}] - Interstitial Ad Shown");
         
         AdOpen?.Invoke();
         AdClose?.Invoke();
      }

      public void ShowRewarded(Action onRewarded)
      {
         Debug.Log($"[{"ELTSDK".WithColor(TextColor.Yellow)}] - Rewarded Ad Shown");
         
         AdOpen?.Invoke();
         onRewarded?.Invoke();
         AdClose?.Invoke();
      }

      public void ShowBanner()
      { 
         Debug.Log($"[{"ELTSDK".WithColor(TextColor.Yellow)}] - Ad Banner Shown");
      }

      public void HideBanner()
      {
         Debug.Log($"[{"ELTSDK".WithColor(TextColor.Yellow)}] - Ad Banner Hidden");
      }
   }
}