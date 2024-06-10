using System.Collections;
using YaSDK.Source.Data;
using YaSDK.Source.SDK.Services.Interfaces;

namespace YaSDK.Source.SDK.Services.EditorServices
{
   internal class EditorEnvironment : IEnvironmentService
   {
      public EnvironmentData EnvironmentData { get; private set; }

      public IEnumerator LoadEnvironmentData()
      {
         yield return null;
      }
   }
}