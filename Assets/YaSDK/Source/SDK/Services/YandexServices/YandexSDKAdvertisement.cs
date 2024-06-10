using System;
using System.Runtime.InteropServices;
using YaSDK.Source.SDK.Services.Interfaces;

namespace YaSDK.Source.SDK.Services.YandexServices
{
   internal class YandexSDKAdvertisement : SingletonBehaviour<YandexSDKAdvertisement>, IAdvertisementService
   {
      [DllImport("__Internal")]
      private static extern void ShowRewardedAdExtern();

      [DllImport("__Internal")]
      private static extern void ShowInterstitialAdExtern();

      [DllImport("__Internal")]
      private static extern void ShowAdBannerExtern();

      [DllImport("__Internal")]
      private static extern void HideAdBannerExtern();
      
      private Action _onRewardedAdShown;
      public void ShowRewardedAd(Action onRewarded)
      {
         _onRewardedAdShown = onRewarded;
         ShowRewardedAdExtern();
      }

      public void ShowInterstitialAd() =>
         ShowInterstitialAdExtern();

      public void ShowAdBanner() =>
         ShowAdBannerExtern();

      public void HideAdBanner() =>
         HideAdBannerExtern();

      private void OnRewardedAdShown()
      {
         _onRewardedAdShown?.Invoke();
         Reset();
      }

      private void OnRewardedAdError() =>
         Reset();

      private void Reset() =>
         _onRewardedAdShown = null;
   }
}