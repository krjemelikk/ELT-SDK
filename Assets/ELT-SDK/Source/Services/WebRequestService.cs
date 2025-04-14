using System;
using System.Collections;
using ELT_SDK.Source.Enum;
using ELT_SDK.Source.Utilities;
using UnityEngine;
using UnityEngine.Networking;

namespace ELT_SDK.Source.Services
{
   public class WebRequestService : SingletonBehaviour<WebRequestService>
   {
      public void DownloadImage(string url, Action<Texture> callback) =>
         StartCoroutine(DownloadImageRoutine(url, callback));

      private IEnumerator DownloadImageRoutine(string url, Action<Texture> callback)
      {
         UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
         yield return request.SendWebRequest();

         if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
         {
            yield break;
         }

         Texture texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
         callback?.Invoke(texture);
      }
   }
}