using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
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