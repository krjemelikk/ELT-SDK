using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using ELT_SDK.Source.Entities;
using ELT_SDK.Source.Enum.JsonConverters;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;
using Newtonsoft.Json;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   internal class YandexEnvironmentService : SingletonBehaviour<YandexEnvironmentService>, IEnvironmentService
   {
      [DllImport("__Internal")]
      private static extern void LoadEnvironmentDataExtern();

      private UniTaskCompletionSource<Environment> _loadCompletionSource;
      public Environment Environment { get; private set; }

      public async UniTask Load()
      {
         _loadCompletionSource = new();
         LoadEnvironmentDataExtern();
         await _loadCompletionSource.Task;
      }

      private void OnEnvironmentDataLoaded(string json)
      {
         Environment = JsonConvert.DeserializeObject<Environment>(json, new JsonSerializerSettings
         {
            Converters = new List<JsonConverter> {new DeviceTypeConverter(), new LanguageConverter()}
         });
         
         _loadCompletionSource.TrySetResult(Environment);
      }
   }
}