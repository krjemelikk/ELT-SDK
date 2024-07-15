using System.Collections;
using ELT_SDK.Source.SDK;
using UnityEngine;

namespace ELT_SDK.Source
{
   public class EntryPoint : MonoBehaviour
   {
      private void Start() =>
         StartCoroutine(Bootstrap());

      private IEnumerator Bootstrap()
      {
         yield return ELTSDK.Instance.Initialize();
         // load game scene here
      }
   }
}