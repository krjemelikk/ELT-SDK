using System.Collections;
using ELT_SDK.Source.Data;
using ELT_SDK.Source.SDK.Services.Interfaces;

namespace ELT_SDK.Source.SDK.Services.EditorServices
{
   internal class EditorEnvironment : IEnvironmentService
   {
      public EditorEnvironment(EnvironmentData environmentData) =>
         EnvironmentData = environmentData;

      public EnvironmentData EnvironmentData { get; private set; }

      public IEnumerator LoadEnvironmentData()
      {
         yield return null;
      }
   }
}