using System;
using ELTSDK.Source.Services.Interfaces;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class FeedbackServiceLogger : IFeedbackService
   {
      private const string Label = "<color=yellow><b>[Feedback]</b></color>";
      private readonly IFeedbackService _service;

      public FeedbackServiceLogger(IFeedbackService service) =>
         _service = service;

      public void SendReviewRequest(Action onFeedbackSent)
      {
         _service.SendReviewRequest(onFeedbackSent);
         Debug.Log($"{Label} - Send Review Request");
      }
   }
   

}