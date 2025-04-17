using System;
using Newtonsoft.Json;

namespace ELT_SDK.Source.Entities
{
   [Serializable]
   public class LeaderboardEntry
   {
      [JsonProperty] public int Rank { get; private set; }
      [JsonProperty] public int Score { get; private set; }
      [JsonProperty] public string Name { get; private set; }
      [JsonProperty] public bool IsPlayer { get; private set; }
   }
}