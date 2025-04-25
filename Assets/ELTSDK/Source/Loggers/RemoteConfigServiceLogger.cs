using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class RemoteConfigServiceLogger : IRemoteConfigService
   {
      private const string Label = "<color=yellow><b>[Remote Config Service]</b></color>";
      private readonly IRemoteConfigService _service;

      public RemoteConfigServiceLogger(IRemoteConfigService service) =>
         _service = service;

      public Dictionary<string, string> Configs => _service.Configs;

      public async UniTask LoadConfigs()
      {
         await _service.LoadConfigs();
         Debug.Log($"{Label} configs loaded: \n {JsonConvert.SerializeObject(Configs, Formatting.Indented)}");
      }
   }
}