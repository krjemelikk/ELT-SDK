using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace ELTSDK.Source.Services.Interfaces
{
   public interface IRemoteConfigService
   {
      Dictionary<string, string> Configs { get; }
      UniTask LoadConfigs();
   }
}