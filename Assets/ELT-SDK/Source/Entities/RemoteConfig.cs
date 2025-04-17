using System;
using Newtonsoft.Json;

namespace ELT_SDK.Source.Entities
{
   [Serializable]
   public class RemoteConfig
   {
      [JsonProperty] public string Name { get; private set; }
      [JsonProperty] public string Value { get; private set; }
   } 
}