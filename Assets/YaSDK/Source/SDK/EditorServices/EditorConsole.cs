using UnityEngine;
using YaSDK.Source.Enum;
using YaSDK.Source.SDK.Interfaces;

namespace YaSDK.Source.SDK.EditorServices
{
   internal class EditorConsole : IConsole
   {
      public void Log(string message, MessageType messageType = MessageType.Info, string filePath = "", int lineNumber = 0)
      {
         Debug.Log($"<color=yellow>Console Message: {messageType.ToString()} </color> {message} " +
                   $"\n File: {filePath} " +
                   $"\n Line: {lineNumber}");
      }
   }
}