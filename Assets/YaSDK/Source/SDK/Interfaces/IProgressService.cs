using System.Collections;
using YaSDK.Source.Data;

namespace YaSDK.Source.SDK.Interfaces
{
   public interface IProgressService
   {
      void SaveProgress(Progress progress);
      IEnumerator LoadProgress();
   }
}