using System.Collections;
using System.Runtime.InteropServices;
using ELT_SDK.Source.Data;
using ELT_SDK.Source.Data.JSON;
using ELT_SDK.Source.Enum;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;
using Newtonsoft.Json;
using UnityEngine;
using DeviceType = ELT_SDK.Source.Enum.DeviceType;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   internal class YandexSDKEnvironment : SingletonBehaviour<YandexSDKEnvironment>, IEnvironmentService
   {
      [DllImport("__Internal")]
      private static extern string LoadEnvironmentDataExtern();

      private bool _isLoaded;
      public EnvironmentData EnvironmentData { get; private set; }

      public IEnumerator LoadEnvironmentData()
      {
         LoadEnvironmentDataExtern();
         yield return new WaitUntil(() => _isLoaded);
      }

      private void OnEnvironmentDataLoaded(string data)
      {
         var dataJson = JsonConvert.DeserializeObject<EnvironmentDataJson>(data);

         EnvironmentData = new EnvironmentData(
            
            dataJson.Device switch
            {
               "desktop" => DeviceType.Desktop,
               "mobile" => DeviceType.Mobile,
               "tablet" => DeviceType.Tablet,
               "tv" => DeviceType.TV,
               _ => DeviceType.Desktop
            },
            
            dataJson.Language is "ru" or "be" or "uk" or "kk" or "az" or "hy"
               ? Language.Russian
               : Language.English,
            
            dataJson.TopLevelDomain
         );

         _isLoaded = true;
      }
   }
}