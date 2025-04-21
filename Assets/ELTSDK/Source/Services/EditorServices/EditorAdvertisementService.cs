using System;
using ELTSDK.Source.Services.Interfaces;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorAdvertisementService : IAdvertisementService
   {
      public event Action AdOpen;
      public event Action AdClose;
      
      public void ShowInterstitial()
      {
         AdOpen?.Invoke();
         AdClose?.Invoke();
      }

      public void ShowRewarded(Action onRewarded)
      {
         AdOpen?.Invoke();
         onRewarded?.Invoke();
         AdClose?.Invoke();
      }

      public void ShowBanner()
      { 
         
      }

      public void HideBanner()
      {
         
      }
   }
}