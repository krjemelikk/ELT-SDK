using System.Collections;
using ELT_SDK.Source.Data;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface IProgressService
   {
      Progress Progress { get; set; }
      IEnumerator LoadProgress();
      void SaveProgress();
   }
}