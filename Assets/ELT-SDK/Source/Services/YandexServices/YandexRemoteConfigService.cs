using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;
using Newtonsoft.Json;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   public class YandexRemoteConfigService : SingletonBehaviour<YandexRemoteConfigService>, IRemoteConfigService
   {
      [DllImport("__Internal")]
      private static extern void LoadConfigsExtern();

      private UniTaskCompletionSource<Dictionary<string, string>> _loadCompletionSource;

      public Dictionary<string, string> Configs { get; private set; } = new();

      public async UniTask LoadConfigs()
      {
         _loadCompletionSource = new();
         LoadConfigsExtern();
         await _loadCompletionSource.Task;
      }

      private void OnConfigsLoaded(string json)
      {
         Configs = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
         _loadCompletionSource.TrySetResult(Configs);
      }
   }
}