using System.Linq;
using System.Runtime.InteropServices;
using ELT_SDK.Source.Enum;
using ELT_SDK.Source.Extensions;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   internal class YandexSDKConsole : SingletonBehaviour<YandexSDKConsole>, IConsole
   {
      [DllImport("__Internal")]
      private static extern void ConsoleLogExtern(
         string message,
         string messageType,
         string messageColor,
         string callerInfo);

      public void Log(
         string message,
         MessageType messageType = MessageType.Info,
         [System.Runtime.CompilerServices.CallerFilePath]
         string filePath = "",
         [System.Runtime.CompilerServices.CallerLineNumber]
         int lineNumber = 0)
      {
         ConsoleLogExtern(
            message,
            messageType.ToString(),
            messageType.ToColor().ToString(),
            $"({filePath.Split('\\').LastOrDefault()}:{lineNumber})".ToString()
         );
      }
   }
}