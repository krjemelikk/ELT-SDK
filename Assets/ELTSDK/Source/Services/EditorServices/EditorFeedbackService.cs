using System;
using ELTSDK.Source.Extensions;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities.Enum;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
{
   public class EditorFeedbackService : IFeedbackService
   {
      public void SendReviewRequest(Action onFeedbackSent)
      {
         Debug.Log($"[{"ELTSDK".WithColor(TextColor.Yellow)}] - Feedback sent");
         onFeedbackSent?.Invoke();
      }
   }
}