using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELT_SDK.Source.Entities;
using ELT_SDK.Source.SDK.Services.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices
{
   internal class EditorLeaderboardService : ILeaderboardService
   {
      private const string EditorLeaderboardPath = "leaderboard";
      public Dictionary<string, Leaderboard> Leaderboards { get; private set; } = new();

      public void SetScoreToLeaderboard(string leaderboardName, int value)
      {
         Debug.Log($"[<color=yellow>ELTSDK</color>] - Set {value} to {leaderboardName} leaderboard");
      }

      public async UniTask UpdateLeaderboard(string leaderboardName)
      {
         var json = Resources.Load<TextAsset>(EditorLeaderboardPath).text;
         var leaderboard = JsonConvert.DeserializeObject<Leaderboard>(json);
         Leaderboards[leaderboardName] = leaderboard;

         await UniTask.CompletedTask;
      }
   }
}