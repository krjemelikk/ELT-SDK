using ELTSDK.Source.Extensions;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities.Enum;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorGameplayMarkupService : IGameplayMarkupService
   {
      public void GameReady()
      {
         Debug.Log($"[{"ELTSDK".WithColor(TextColor.Yellow)}] - Game ready API called");
      }
   }
}