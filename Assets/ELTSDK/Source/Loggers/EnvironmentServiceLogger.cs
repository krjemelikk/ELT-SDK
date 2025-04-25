using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Enum.JsonConverters;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class EnvironmentServiceLogger : IEnvironmentService
   {
      private const string Label = "<color=yellow><b>[Environment]</b></color>";

      private readonly IEnvironmentService _service;

      public EnvironmentServiceLogger(IEnvironmentService service) =>
         _service = service;

      public Environment Environment => _service.Environment;

      public async UniTask Load()
      {
         await _service.Load();
         
         var data = JsonConvert.SerializeObject(Environment, Formatting.Indented, new JsonSerializerSettings
         {
            Converters = new List<JsonConverter> {new DeviceTypeConverter(), new LanguageConverter()}
         });
         
         Debug.Log($"{Label} - Environment loaded: \n {data}");
      }
   }
}