using System;
using Newtonsoft.Json;

namespace ELTSDK.Source.Entities
{
   [Serializable]
   public class RemoteConfig
   {
      [JsonProperty] public string Name { get; private set; }
      [JsonProperty] public string Value { get; private set; }
   } 
}