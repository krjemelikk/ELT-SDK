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

      private event Action _callback;

      public void ShowRewardedAd(Action callback)
      {
         ShowRewardedAdExtern();
         SetCallback(callback);
      }

      public void ShowInterstitialAd() =>
         ShowInterstitialAdExtern();

      public void ShowAdBanner() =>
         ShowAdBannerExtern();

      public void HideAdBanner() =>
         HideAdBannerExtern();

      private void OnRewardedAdShown()
      {
         _callback?.Invoke();
         ResetCallback();
      }

      private void SetCallback(Action callback) =>
         _callback += callback;

      private void ResetCallback() =>
         _callback = null;
   }
}