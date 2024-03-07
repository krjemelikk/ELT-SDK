using System.Runtime.InteropServices;
using YaSDK.Source.SDK.Services.Interfaces;

namespace YaSDK.Source.SDK.Services.YandexServices
{
   internal class YandexSDKGameReadyAPI : SingletonBehaviour<YandexSDKGameReadyAPI>, IGameReadyAPIService
   {
      [DllImport("__Internal")]
      private static extern void GameReadyExtern();

      public void GameReadyAPI() =>
         GameReadyExtern();
   }
}