using System.Linq;
using System.Runtime.InteropServices;
using Source.Enum;
using Source.Extensions;

namespace Source.SDK
{
   public class YandexSDKConsole : SingletonBehaviour<YandexSDKConsole>
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