using System.Runtime.InteropServices;
using UnityEngine;

namespace Source.SDK
{
   public class YandexSDK : SingletonBehaviour<YandexSDK>
   {
      [DllImport("__Internal")]
      private static extern void GameReadyExtern();

      private void Awake() =>
         DontDestroyOnLoad(this);

      public void GameReady() =>
         GameReadyExtern();

      public void PauseGame()
      {
         Time.timeScale = 0;
         AudioListener.pause = true;
      }

      public void UnPauseGame()
      {
         Time.timeScale = 1;
         AudioListener.pause = false;
      }
   }
}