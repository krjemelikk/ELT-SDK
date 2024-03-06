using System.Collections;
using YaSDK.Source.Data;

namespace YaSDK.Source.SDK.Services.Interfaces
{
   public interface IProgressService
   {
      void SaveProgress(Progress progress);
      IEnumerator LoadProgress();
   }
}