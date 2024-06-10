using System;
using YaSDK.Source.Enum;
using DeviceType = YaSDK.Source.Enum.DeviceType;

namespace YaSDK.Source.Data
{
   [Serializable]
   public class EnvironmentData
   { 
      public DeviceType DeviceType { get; private set; } 
      public Language Language { get; private set; } 
      public string TopLevelDomain { get; private set; }

      public EnvironmentData(DeviceType deviceType, Language language, string topLevelDomain)
      {
         DeviceType = deviceType;
         Language = language;
         TopLevelDomain = topLevelDomain;
      }
   }
}