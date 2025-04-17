using System;
using ELTSDK.Source.Enum;
using Newtonsoft.Json;

namespace ELTSDK.Source.Entities
{
   [Serializable]
   public class Environment
   {
      [JsonProperty] public DeviceType DeviceType { get; private set; }
      [JsonProperty] public Language Language { get; private set; }
   }
}