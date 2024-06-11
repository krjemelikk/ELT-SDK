using System.Collections;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using YaSDK.Source.SDK.Services.Interfaces;
using Progress = YaSDK.Source.Data.Progress;

namespace YaSDK.Source.SDK.Services.EditorServices
{
   internal class EditorProgress : IProgressService
   {
      public Progress Progress { get; private set; }

      public void SaveProgress()
      {
         var json = JsonConvert.SerializeObject(Progress);
         PlayerPrefs.SetString("Progress", json);
      }

      public IEnumerator LoadProgress()
      {
         if (PlayerPrefs.HasKey("Progress"))
         {
            Progress = JsonConvert.DeserializeObject<Progress>(PlayerPrefs.GetString("Progress"));
            yield return null;
         }

         Progress = new Progress();
         yield return null;
      }
#if UNITY_EDITOR
      [MenuItem("YandexSDK/Clean editor progress")]
      public static void CleanUp()
      {
         PlayerPrefs.DeleteAll();
      }
#endif
   }
}