using System;
using ELTSDK.Source.Services.Interfaces;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class AdvertisementServiceLogger : IAdvertisementService, IDisposable
   {
      private const string Label = "<color=yellow><b>[Advertisement]</b></color>";
      private readonly IAdvertisementService _service;

      public AdvertisementServiceLogger(IAdvertisementService service)
      {
         _service = service;
         AdOpen += OnAdOpen;
         AdClose += OnAdClose;
      }

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
         Debug.Log($"{Label} - Interstitial ad");
         _service.ShowInterstitial();
      }

      public void ShowRewarded(Action onRewarded)
      {
         Debug.Log($"{Label} - Rewarded ad");
         _service.ShowRewarded(onRewarded);
      }

      public void ShowBanner()
      {
         Debug.Log($"{Label} - Show ad banner");
         _service.ShowBanner();
      }

      public void HideBanner()
      {
         Debug.Log($"{Label} - Hide ad banner");
         _service.HideBanner();
      }

      public void Dispose()
      {
         AdOpen -= OnAdOpen;
         AdClose -= OnAdClose;
      }

      private void OnAdOpen() =>
         Debug.Log($"{Label} - Ad open");

      private void OnAdClose() =>
         Debug.Log($"{Label} - Ad close");
   }
}