using System;
using ELT_SDK.Source.Enum;
using UnityEngine;
using DeviceType = ELT_SDK.Source.Enum.DeviceType;

namespace ELT_SDK.Source.Data
{
   [Serializable]
   public class EnvironmentData
   { 
      [field: SerializeField] public DeviceType DeviceType { get; private set; } 
      [field: SerializeField] public Language Language { get; private set; } 
      [field: SerializeField] public string TopLevelDomain { get; private set; }

      public EnvironmentData(DeviceType deviceType, Language language, string topLevelDomain)
      {
         DeviceType = deviceType;
         Language = language;
         TopLevelDomain = topLevelDomain;
      }
   }
}