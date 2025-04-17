using System;

namespace ELTSDK.Source.Services.Interfaces
{
   public interface IFeedbackService
   {
      void SendReviewRequest(Action onFeedbackSent);
   }
}