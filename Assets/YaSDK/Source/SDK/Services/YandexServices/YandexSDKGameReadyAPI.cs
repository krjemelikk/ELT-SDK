using System.Runtime.InteropServices;
using YaSDK.Source.SDK.Interfaces;

namespace YaSDK.Source.SDK.YandexServices
{
   public class YandexSDKGameReadyAPI : SingletonBehaviour<YandexSDKGameReadyAPI>, IGameReadyAPIService
   {
      [DllImport("__Internal")]
      private static extern void GameReadyExtern();

      public void GameReadyAPI() =>
         GameReadyExtern();
   }
}