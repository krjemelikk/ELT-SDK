using Cysharp.Threading.Tasks;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class SaveLoadServiceLogger : ISaveLoadService
   {
      private const string Label = "<color=yellow><b>[Save Load Service]</b></color>";
      private readonly ISaveLoadService _service;

      public SaveLoadServiceLogger(ISaveLoadService service) =>
         _service = service;

      public string Json => _service.Json;

      public void Save(string json)
      {
         _service.Save(json);
         Debug.Log($"{Label} - Data Saved: {JsonConvert.SerializeObject(json, Formatting.Indented)}");
      }

      public async UniTask Load()
      {
         await _service.Load();
         Debug.Log($"{Label} - Data Loaded: {JsonConvert.SerializeObject(Json, Formatting.Indented)}");
      }
   }
}