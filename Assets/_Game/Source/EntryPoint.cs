using System;
using System.Collections;
using Source.SDK;
using UnityEngine;

namespace _Game.Source
{
   public class EntryPoint : MonoBehaviour
   {
      public void Start()
      {
         StartCoroutine(LoadData(DoSomething));
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