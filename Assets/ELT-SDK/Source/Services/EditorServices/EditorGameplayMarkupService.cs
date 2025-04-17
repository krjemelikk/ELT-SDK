using ELT_SDK.Source.Extensions;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities.Enum;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices
{
   internal class EditorGameplayMarkupService : IGameplayMarkupService
   {
      public void GameReady()
      {
         Debug.Log($"[{"ELTSDK".WithColor(TextColor.Yellow)}] - Game ready API called");
      }
   }
}