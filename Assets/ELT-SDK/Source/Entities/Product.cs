using System;
using Newtonsoft.Json;

namespace ELT_SDK.Source.Entities
{
   [Serializable]
   public class Product
   {
      [JsonProperty] public string Id { get; private set; }
      [JsonProperty] public string Price { get; private set; }
      [JsonProperty] public string CurrencyImageURL { get; private set; }
   }
}