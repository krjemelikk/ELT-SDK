using UnityEngine;
using YaSDK.Source.SDK.Interfaces;

namespace YaSDK.Source.SDK.EditorServices
{
   public class EditorGameReadyAPI : IGameReadyAPIService
   {
      public void GameReadyAPI()
      {
         Debug.Log("<color=blue>Advertisement: </color>Game ready API called");
      }
   }
}