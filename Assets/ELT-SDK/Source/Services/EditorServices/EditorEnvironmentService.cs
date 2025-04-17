using Cysharp.Threading.Tasks;
using ELT_SDK.Source.Entities;
using ELT_SDK.Source.SDK.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices
{
   public class EditorEnvironmentService : IEnvironmentService
   {
      private const string EditorEnvironmentPath = "environment";
      public Environment Environment { get; private set; }

      public async UniTask Load()
      {
         var json = Resources.Load<TextAsset>(EditorEnvironmentPath).text;
         Environment = JsonConvert.DeserializeObject<Environment>(json);
         await UniTask.CompletedTask;
      }
   }
}