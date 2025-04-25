using System;
using ELTSDK.Source.Services.Interfaces;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class AdvertisementServiceLogger : IAdvertisementService
   {
      private const string Label = "<color=yellow><b>[Advertisement]</b></color>"; 
      private readonly IAdvertisementService _service;

      public AdvertisementServiceLogger(IAdvertisementService service) =>
         _service = service;

      public event Action AdOpen
      {
         add => _service.AdOpen += value;
         remove => _service.AdOpen -= value;
      }

      public event Action AdClose
      {
         add => _service.AdClose += value;
         remove => _service.AdClose -= value;
      }

      public void ShowInterstitial()
      {
         _service.ShowInterstitial();
         Debug.Log($"{Label} - Interstitial ad");
      }

      public void ShowRewarded(Action onRewarded)
      {
         _service.ShowRewarded(onRewarded);
         Debug.Log($"{Label} - Rewarded ad");
      }

      public void ShowBanner()
      {
         _service.ShowBanner();
         Debug.Log($"{Label} - Show ad banner");
      }

      public void HideBanner()
      {
         _service.HideBanner();
         Debug.Log($"{Label} - Hide ad banner");
      }
   }
}