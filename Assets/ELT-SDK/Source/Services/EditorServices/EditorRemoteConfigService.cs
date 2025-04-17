using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using ELT_SDK.Source.Entities;
using ELT_SDK.Source.SDK.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices
{
   public class EditorRemoteConfigService : IRemoteConfigService
   {
      private const string EditorConfigsPath = "configs";
      public Dictionary<string, string> Configs { get; private set; } = new();

      public async UniTask LoadConfigs()
      {
         var json = Resources.Load<TextAsset>(EditorConfigsPath).text;
         var configs = JsonConvert.DeserializeObject<List<RemoteConfig>>(json);
         Configs = configs.ToDictionary(x => x.Name, x => x.Value);
         
         await UniTask.CompletedTask;
      }
   }
}