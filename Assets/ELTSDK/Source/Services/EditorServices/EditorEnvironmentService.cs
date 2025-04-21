using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Enum.JsonConverters;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorEnvironmentService : IEnvironmentService
   {
      private const string EditorEnvironmentPath = "environment";
      public Environment Environment { get; private set; }

      public async UniTask Load()
      {
         var json = Resources.Load<TextAsset>(EditorEnvironmentPath).text;
         Environment = JsonConvert.DeserializeObject<Environment>(json, new JsonSerializerSettings
         {
            Converters = new List<JsonConverter> {new DeviceTypeConverter(), new LanguageConverter()}
         });
         
         await UniTask.CompletedTask;
      }
   }
}