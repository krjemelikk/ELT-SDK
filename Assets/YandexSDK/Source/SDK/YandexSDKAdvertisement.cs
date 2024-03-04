using System;
using System.Runtime.InteropServices;

namespace Source.SDK
{
   public class YandexSDKAdvertisement : SingletonBehaviour<YandexSDKAdvertisement>
   {
      [DllImport("__Internal")]
      private static extern void ShowRewardedAdExtern();

      [DllImport("__Internal")]
      private static extern void ShowInterstitialAdExtern();

      [DllImport("__Internal")]
      private static extern void ShowAdBannerExtern();

      [DllImport("__Internal")]
      private static extern void HideAdBannerExtern();

      public event Action RewardedAdShown;

      public void ShowRewardedAd() =>
         ShowRewardedAdExtern();

      public void ShowInterstitialAd() =>
         ShowInterstitialAdExtern();

      public void ShowAdBanner() =>
         ShowAdBannerExtern();

      public void HideAdBanner() =>
         HideAdBannerExtern();

      private void OnRewardedAdShown() =>
         RewardedAdShown?.Invoke();
   }
}