using System;
using System.Collections;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;

namespace Source.SDK
{
   public class YandexSDKProgress : SingletonBehaviour<YandexSDKProgress>
   {
      [DllImport("__Internal")]
      private static extern void SaveProgressExtern(string data);

      [DllImport("__Internal")]
      private static extern string LoadProgressExtern();

      public Progress Progress { get; private set; }

      private bool _isLoaded;

      public void SaveProgress()
      {
         var json = JsonConvert.SerializeObject(Progress);
         SaveProgressExtern(json);
      }

      public IEnumerator LoadProgress()
      {
         LoadProgressExtern();
         yield return new WaitUntil(() => _isLoaded);
      }

      private void OnProgressLoaded(string json)
      {
         Progress = String.IsNullOrEmpty(json) || json == "{}"
            ? new Progress()
            : JsonConvert.DeserializeObject<Progress>(json);

         _isLoaded = true;
      }
   }

   [Serializable]
   public class Progress
   {
      public Progress()
      {
      }
   }
}