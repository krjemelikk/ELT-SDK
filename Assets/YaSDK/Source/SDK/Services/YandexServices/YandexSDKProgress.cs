using System;
using System.Collections;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;
using YaSDK.Source.Data;
using YaSDK.Source.SDK.Services.Interfaces;

namespace YaSDK.Source.SDK.Services.YandexServices
{
   internal class YandexSDKProgress : SingletonBehaviour<YandexSDKProgress>, IProgressService
   {
      [DllImport("__Internal")]
      private static extern void SaveProgressExtern(string data);

      [DllImport("__Internal")]
      private static extern string LoadProgressExtern();

      private bool _isLoaded;
      public Progress Progress { get; private set; }

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
}