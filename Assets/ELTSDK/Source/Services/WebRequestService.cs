using System;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Utilities;
using UnityEngine;
using UnityEngine.Networking;

namespace ELTSDK.Source.Services
{
   public class WebRequestService : SingletonBehaviour<WebRequestService>
   {
      public async UniTask<Texture> DownloadTexture(string url)
      {
         try
         {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            await request.SendWebRequest().ToUniTask();

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
               throw new Exception(request.error);

            Texture2D texture = ((DownloadHandlerTexture) request.downloadHandler).texture;

            return texture;
         }

         catch (Exception e)
         {
            Debug.Log(e);
            throw;
         }
      }
   }
}