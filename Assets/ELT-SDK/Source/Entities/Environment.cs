using System;
using ELT_SDK.Source.Enum;
using Newtonsoft.Json;

namespace ELT_SDK.Source.Entities
{
   [Serializable]
   public class Environment
   {
      [JsonProperty] public DeviceType DeviceType { get; private set; }
      [JsonProperty] public Language Language { get; private set; }
   }
}