using System;
using ELT_SDK.Source.Utilities.Enum;

namespace ELT_SDK.Source.Extensions
{
   public static class UnityDebugExtensions
   {
      public static string WithColor(this string str, TextColor color)
      {
         switch (color)
         {
            case TextColor.None:
               return str;
            case TextColor.Red:
               return $"<color=red>{str}</color>";
            case TextColor.Green: 
               return $"<color=green>{str}</color>";
            case TextColor.Blue:
               return $"<color=blue>{str}</color>";
            case TextColor.Yellow:
               return $"<color=yellow>{str}</color>";
            default:
               return str; 
            
         }
      }
   }
}