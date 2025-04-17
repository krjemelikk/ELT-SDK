using System.Collections;
using Cysharp.Threading.Tasks;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface ISaveLoadService
   {
      string Json { get; }
      UniTask Load();
      void Save(string json);
   }
}