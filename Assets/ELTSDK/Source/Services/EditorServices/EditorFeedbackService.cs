using System;
using ELTSDK.Source.Services.Interfaces;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorFeedbackService : IFeedbackService
   {
      public void SendReviewRequest(Action onFeedbackSent)
      {
         onFeedbackSent?.Invoke();
      }
   }
}