using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;
using ELTSDK.Source.Services.Interfaces;
using ELTSDK.Source.Utilities;
using Newtonsoft.Json;

namespace ELTSDK.Source.Services.YandexServices
{
   internal class YandexLeaderboardService : SingletonBehaviour<YandexLeaderboardService>, ILeaderboardService
   {
      [DllImport("__Internal")]
      private static extern void SetScoreToLeaderboardExtern(string leaderboardName, int value);

      [DllImport("__Internal")]
      private static extern void LoadLeaderboardExtern(string leaderboardName);

      private UniTaskCompletionSource<Leaderboard> _loadCompletionSource;

      public Dictionary<string, Leaderboard> Leaderboards { get; } = new();

      public event Action<string> LeaderboardUpdated;

      public void SetScoreToLeaderboard(string leaderboardName, int value) =>
         SetScoreToLeaderboardExtern(leaderboardName, value);

      public async UniTask LoadLeaderboard(string leaderboardName)
      {
         _loadCompletionSource = new();
         LoadLeaderboardExtern(leaderboardName);
         await _loadCompletionSource.Task;
      }

      private void OnLeaderboardLoaded(string json)
      {
         Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(json);
         Leaderboards[leaderboard.Name] = leaderboard;
         _loadCompletionSource.TrySetResult(leaderboard);
      }

      private void OnLeaderboardScoreSet(string leaderboardName)
      {
         LeaderboardUpdated?.Invoke(leaderboardName);
      }
   }
}