using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   internal class YandexSaveLoadService : SingletonBehaviour<YandexSaveLoadService>, ISaveLoadService
   {
      [DllImport("__Internal")]
      private static extern void SaveExtern(string json);

      [DllImport("__Internal")]
      private static extern void LoadExtern();

      private UniTaskCompletionSource<string> _loadCompletionSource;
      public string Json { get; private set; }

      public void Save(string json) =>
         SaveExtern(json);

      public async UniTask Load()
      {
         _loadCompletionSource = new();
         LoadExtern();
         await _loadCompletionSource.Task;
      }

      private void OnLoaded(string json)
      {
         Json = json;
         _loadCompletionSource.TrySetResult(json);
      }
   }
}