using System;
using System.Collections;
using System.Runtime.InteropServices;
using ELT_SDK.Source.Data;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;
using Newtonsoft.Json;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   internal class YandexSDKProgress : SingletonBehaviour<YandexSDKProgress>, IProgressService
   {
      [DllImport("__Internal")]
      private static extern void SaveProgressExtern(string data);

      [DllImport("__Internal")]
      private static extern string LoadProgressExtern();

      private bool _isLoaded;
      public Progress Progress { get; set; }

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