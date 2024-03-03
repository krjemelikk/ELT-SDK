using System;
using System.Collections;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Source.Enum;
using UnityEngine;
using DeviceType = Source.Enum.DeviceType;

namespace Source.SDK
{
   public class YandexSDKEnvironment : SingletonBehaviour<YandexSDKEnvironment>
   {
      [DllImport("__Internal")]
      private static extern string LoadEnvironmentDataExtern();

      [field: SerializeField] public EnvironmentData EnvironmentData { get; private set; }

      private bool _isLoaded;

      public IEnumerator LoadEnvironmentData()
      {
         LoadEnvironmentDataExtern();
         yield return new WaitUntil(() => _isLoaded);
      }

      private void OnEnvironmentDataLoaded(string data)
      {
         var dataJson = JsonConvert.DeserializeObject<EnvironmentDataJson>(data);
         EnvironmentData = new EnvironmentData(dataJson);

         _isLoaded = true;
      }
   }

   [Serializable]
   public class EnvironmentData
   {
      [field: SerializeField] public DeviceType DeviceType { get; private set; }
      [field: SerializeField] public Language Language { get; private set; }
      [field: SerializeField] public string TopLevelDomain { get; private set; }

      public EnvironmentData(EnvironmentDataJson json)
      {
         DeviceType = json.Device switch
         {
            "desktop" => DeviceType.Desktop,
            "mobile" => DeviceType.Mobile,
            "tablet" => DeviceType.Tablet,
            "tv" => DeviceType.TV,
            _ => DeviceType.Desktop
         };

         Language = json.Language is "ru" or "be" or "uk" or "kk" or "az" or "hy"
            ? Language.Russian
            : Language.English;

         TopLevelDomain = json.TopLevelDomain;
      }
   }

   [Serializable]
   public class EnvironmentDataJson
   {
      public string Device;
      public string Language;
      public string TopLevelDomain;
   }
}