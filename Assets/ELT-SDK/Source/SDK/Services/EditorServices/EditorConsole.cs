using ELT_SDK.Source.Enum;
using ELT_SDK.Source.SDK.Services.Interfaces;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices
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