using System;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface IFeedbackService
   {
      void SendReviewRequest(Action onFeedbackSent);
   }
}