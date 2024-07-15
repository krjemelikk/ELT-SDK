using System.Runtime.InteropServices;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   internal class YandexSDKGameReady : SingletonBehaviour<YandexSDKGameReady>, IGameReadyService
   {
      [DllImport("__Internal")]
      private static extern void GameReadyExtern();

      public void GameReadyAPI() =>
         GameReadyExtern();
   }
}