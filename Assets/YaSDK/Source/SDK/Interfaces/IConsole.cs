using YaSDK.Source.Enum;

namespace YaSDK.Source.SDK.Interfaces
{
   public interface IConsole
   {
      void Log(
         string message,
         MessageType messageType = MessageType.Info,
         [System.Runtime.CompilerServices.CallerFilePath]
         string filePath = "",
         [System.Runtime.CompilerServices.CallerLineNumber]
         int lineNumber = 0);
   }
}