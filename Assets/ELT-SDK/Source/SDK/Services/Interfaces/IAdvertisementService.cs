using System;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface IAdvertisementService
   {
      void ShowRewardedAd(Action onRewarded);

      void ShowInterstitialAd();

      void ShowAdBanner();

      void HideAdBanner();
   }
}