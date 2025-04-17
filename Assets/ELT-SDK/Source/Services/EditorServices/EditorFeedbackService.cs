using System;
using ELT_SDK.Source.Extensions;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities.Enum;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices
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