using Cysharp.Threading.Tasks;
using ELT_SDK.Source.Entities;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface IEnvironmentService
   {
      Environment Environment { get; }
      UniTask Load();
   }
}