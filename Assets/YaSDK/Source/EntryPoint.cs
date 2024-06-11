using System.Collections;
using Newtonsoft.Json;
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
         // load game scene here
      }
   }
}