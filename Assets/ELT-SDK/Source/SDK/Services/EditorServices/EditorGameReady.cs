using ELT_SDK.Source.SDK.Services.Interfaces;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices
{
   internal class EditorGameReady : IGameReadyService
   {
      public void GameReadyAPI()
      {
         Debug.Log("<color=blue>Advertisement: </color>Game ready API called");
      }
   }
}