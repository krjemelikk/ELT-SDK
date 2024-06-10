using System.Collections;
using YaSDK.Source.Data;

namespace YaSDK.Source.SDK.Services.Interfaces
{
   public interface IEnvironmentService
   {
      EnvironmentData EnvironmentData { get; }
      IEnumerator LoadEnvironmentData();
   }
}