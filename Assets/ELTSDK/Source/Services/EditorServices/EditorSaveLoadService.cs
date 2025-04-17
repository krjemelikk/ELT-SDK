using Cysharp.Threading.Tasks;
using ELTSDK.Source.Services.Interfaces;
using UnityEditor;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorSaveLoadService : ISaveLoadService
   {
      private const string ProgressKey = "Progress";

      public string Json { get; private set; }

      public void Save(string json)
      {
         PlayerPrefs.SetString(ProgressKey, json);
      }

      public async UniTask Load()
      { 
         Json = PlayerPrefs.HasKey(ProgressKey)
            ? PlayerPrefs.GetString(ProgressKey) 
            : string.Empty;
         
         await UniTask.CompletedTask;
      }

#if UNITY_EDITOR
      [MenuItem("ELTSDK/Clean editor progress")]
      public static void CleanUp()
      {
         PlayerPrefs.DeleteAll();
      }
#endif
   }
}