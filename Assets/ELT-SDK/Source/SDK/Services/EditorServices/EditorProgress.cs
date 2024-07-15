using System.Collections;
using ELT_SDK.Source.SDK.Services.Interfaces;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using Progress = ELT_SDK.Source.Data.Progress;

namespace ELT_SDK.Source.SDK.Services.EditorServices
{
   internal class EditorProgress : IProgressService
   {
      public Progress Progress { get; set; }

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