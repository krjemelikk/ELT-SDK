using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;

namespace ELTSDK.Source.Services.Interfaces
{
   public interface IEnvironmentService
   {
      Environment Environment { get; }
      UniTask Load();
   }
}