using System;
using Newtonsoft.Json;

namespace ELTSDK.Source.Entities
{
   [Serializable]
   public class Product
   {
      [JsonProperty] public string Id { get; private set; }
      [JsonProperty] public string Title { get; private set; }
      [JsonProperty] public string Price { get; private set; }
      [JsonProperty] public string CurrencyImageURL { get; private set; }
   }
}