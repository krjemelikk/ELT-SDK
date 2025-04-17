using System.Runtime.InteropServices;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   internal class YandexGameplayMarkupService : SingletonBehaviour<YandexGameplayMarkupService>, IGameplayMarkupService
   {
      [DllImport("__Internal")]
      private static extern void GameReadyExtern();
      
      public void GameReady() =>
         GameReadyExtern();
   }
}