using System;
using System.Collections;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;
using YaSDK.Source.Data;
using YaSDK.Source.SDK.Interfaces;

namespace YaSDK.Source.SDK.YandexServices
{
   public class YandexSDKProgress : SingletonBehaviour<YandexSDKProgress>, IProgressService
   {
      [DllImport("__Internal")]
      private static extern void SaveProgressExtern(string data);

      [DllImport("__Internal")]
      private static extern string LoadProgressExtern();

      private bool _isLoaded;

      public void SaveProgress(Progress progress)
      {
         var json = JsonConvert.SerializeObject(progress);
         SaveProgressExtern(json);
      }

      public IEnumerator LoadProgress()
      {
         LoadProgressExtern();
         yield return new WaitUntil(() => _isLoaded);
      }

      private void OnProgressLoaded(string json)
      {
         YandexSDKData.Instance.Progress = String.IsNullOrEmpty(json) || json == "{}"
            ? new Progress()
            : JsonConvert.DeserializeObject<Progress>(json);

         _isLoaded = true;
      }
   }
}