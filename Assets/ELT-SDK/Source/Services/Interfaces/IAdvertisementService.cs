using System;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface IAdvertisementService
   {
      event Action AdOpen;
      event Action AdClose;
      
      void ShowInterstitial();
      void ShowRewarded(Action onRewarded);
      void ShowBanner();
      void HideBanner();
   }
}