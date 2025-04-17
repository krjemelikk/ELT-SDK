using Cysharp.Threading.Tasks;

namespace ELTSDK.Source.Services.Interfaces
{
   public interface ISaveLoadService
   {
      string Json { get; }
      UniTask Load();
      void Save(string json);
   }
}