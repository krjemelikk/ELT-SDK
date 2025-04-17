using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ELTSDK.Source.Entities
{
   [Serializable]
   public class Leaderboard
   {
      [JsonProperty] public string Name { get; private set; }
      [JsonProperty] public List<LeaderboardEntry> Entries { get; private set; }
   }
}