using System;
using System.Collections;
using UnityEngine;
using YaSDK.Source.SDK;
using YaSDK.Source.SDK.YandexServices;

namespace _Game.Source
{
   public class EntryPoint : MonoBehaviour
   {
      public void Start()
      {
         YandexSDK.Instance.Initialize();
         YandexSDK.Instance.Console.Log("Yandex SDK initialized");
         YandexSDKConsole.Instance.Log("Yandex SDK initialized via console");
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