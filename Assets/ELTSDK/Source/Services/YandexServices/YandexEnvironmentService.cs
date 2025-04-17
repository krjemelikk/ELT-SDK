using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Enum.JsonConverters;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities;
using Newtonsoft.Json;

namespace ELTSDK.Source.Services.YandexServices
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