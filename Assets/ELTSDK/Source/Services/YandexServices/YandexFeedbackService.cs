using System;
using System.Runtime.InteropServices;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities;

namespace ELTSDK.Source.Services.YandexServices
{
   public class YandexFeedbackService : SingletonBehaviour<YandexFeedbackService>, IFeedbackService
   {
      [DllImport("__Internal")]
      private static extern void ReviewRequestExtern();
      
      private Action _feedbackSent;
      
      public void SendReviewRequest(Action onFeedbackSent)
      {
         ReviewRequestExtern();
         _feedbackSent = onFeedbackSent;
      }

      private void OnFeedbackSent()
      {
         _feedbackSent?.Invoke();
         _feedbackSent = null;
      }
   }
}