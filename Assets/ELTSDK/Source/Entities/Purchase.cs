using System;
using Newtonsoft.Json;

namespace ELTSDK.Source.Entities
{
   [Serializable]
   public class Purchase
   {
      [JsonProperty] public string ProductId { get; private set; }
      [JsonProperty] public string Token { get; private set; }
      [JsonProperty] public bool WithConsume { get; private set; }
   }
}