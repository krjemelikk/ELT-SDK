using System;
using System.Collections;
using UnityEngine;
using YaSDK.Source.SDK;

namespace YaSDK.Source
{
   public class EntryPoint : MonoBehaviour
   {
      private void Start() =>
         StartCoroutine(Bootstrap());

      private IEnumerator Bootstrap()
      {
         yield return YandexSDK.Instance.Initialize();
         // Load Game Scene Here
      }
   }
}