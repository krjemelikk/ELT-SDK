using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELTSDK.Source.Services.EditorServices
{
   internal class EditorLeaderboardService : ILeaderboardService
   {
      private const string EditorLeaderboardPath = "leaderboard";
      public Dictionary<string, Leaderboard> Leaderboards { get; private set; } = new();

      public event Action<string> LeaderboardUpdated;

      public void SetScoreToLeaderboard(string leaderboardName, int value)
      {
         LeaderboardUpdated?.Invoke(leaderboardName);
      }

      public async UniTask LoadLeaderboard(string leaderboardName)
      {
         var json = Resources.Load<TextAsset>(EditorLeaderboardPath).text;
         var leaderboard = JsonConvert.DeserializeObject<Leaderboard>(json);
         Leaderboards[leaderboardName] = leaderboard;

         await UniTask.CompletedTask;
      }
   }
}