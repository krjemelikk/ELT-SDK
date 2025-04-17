using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface IRemoteConfigService
   {
      Dictionary<string, string> Configs { get; }
      UniTask LoadConfigs();
   }
}