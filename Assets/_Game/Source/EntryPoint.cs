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
      }

      private void DoSomething()
      {
      }

      private IEnumerator LoadData(Action onLoaded)
      {
         yield return StartCoroutine(YandexSDK.Instance.EnvironmentService.LoadEnvironmentData());
         yield return StartCoroutine(YandexSDK.Instance.ProgressService.LoadProgress());
         yield return StartCoroutine(YandexSDK.Instance.ProductsService.LoadProductData());

         onLoaded?.Invoke();
      }
   }
}