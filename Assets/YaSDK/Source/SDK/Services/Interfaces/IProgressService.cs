using System.Collections;
using YaSDK.Source.Data;

namespace YaSDK.Source.SDK.Services.Interfaces
{
   public interface IProgressService
   {
      Progress Progress { get; }
      void SaveProgress();
      IEnumerator LoadProgress();
   }
}