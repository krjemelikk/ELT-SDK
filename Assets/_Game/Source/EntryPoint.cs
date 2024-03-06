using System;
using System.Collections;
using UnityEngine;
using YaSDK.Source.SDK;
using YaSDK.Source.SDK.Services;

namespace _Game.Source
{
   public class EntryPoint : MonoBehaviour
   {
      public void Start()
      {
         
         YandexSDK.Instance.Initialize();
      }

      private void DoSomething()
      {
         YandexSDKConsole.Instance.Log("All data loaded");
      }

      private IEnumerator LoadData(Action onLoaded)
      {
         yield return StartCoroutine(YandexSDKProgress.Instance.LoadProgress());
         yield return StartCoroutine(YandexSDKEnvironment.Instance.LoadEnvironmentData());
         yield return StartCoroutine(YandexSDKProducts.Instance.LoadProductData());

         onLoaded?.Invoke();
      }
   }
}