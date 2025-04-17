using System;
using System.Runtime.InteropServices;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   internal class YandexAdvertisementService : SingletonBehaviour<YandexAdvertisementService>, IAdvertisementService
   {
      [DllImport("__Internal")]
      private static extern void ShowInterstitialAdExtern();
      
      [DllImport("__Internal")] 
      private static extern void ShowRewardedAdExtern();
      
      [DllImport("__Internal")]
      private static extern void ShowAdBannerExtern();
      
      [DllImport("__Internal")] 
      private static extern void HideAdBannerExtern();
      
      
      private Action _rewardedAdShown;
      
      public event Action AdOpen;
      public event Action AdClose;
      
      public void ShowInterstitial()
      { 
         ShowInterstitialAdExtern();
      }

      public void ShowRewarded(Action onRewarded)
      {
         _rewardedAdShown = onRewarded;
         ShowRewardedAdExtern();
      }

      public void ShowBanner()
      {
         ShowAdBannerExtern();
      }

      public void HideBanner()
      {
         HideAdBannerExtern();
      }

      private void OnAdOpen()
      {
         AdOpen?.Invoke();
      }

      private void OnAdClose()
      {
         AdClose?.Invoke();
      }

      private void OnRewardedAdShown()
      {
         _rewardedAdShown?.Invoke();
         _rewardedAdShown = null;
      }
   }
}