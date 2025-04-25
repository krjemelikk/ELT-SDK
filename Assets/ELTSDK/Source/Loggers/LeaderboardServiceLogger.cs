using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Loggers
{
   internal class LeaderboardServiceLogger : ILeaderboardService
   {
      private const string Label = "<color=yellow><b>[Leaderboad]</b></color>";
      private readonly ILeaderboardService _service;

      public LeaderboardServiceLogger(ILeaderboardService service) =>
         _service = service;

      public Dictionary<string, Leaderboard> Leaderboards => _service.Leaderboards;

      public event Action<string> LeaderboardUpdated
      {
         add => _service.LeaderboardUpdated += value;
         remove => _service.LeaderboardUpdated -= value;
      }

      public void SetScoreToLeaderboard(string leaderboardName, int value)
      {
         _service.SetScoreToLeaderboard(leaderboardName, value);
         Debug.Log($"{Label} - Set {value} to leaderboard with name: {leaderboardName}");
      }

      public async UniTask LoadLeaderboard(string leaderboardName)
      {
         await _service.LoadLeaderboard(leaderboardName);
         Debug.Log($"{Label} - Leaderboard loaded: \n " +
                   $"{JsonConvert.SerializeObject(Leaderboards[leaderboardName], Formatting.Indented)}");
      }
   }
}