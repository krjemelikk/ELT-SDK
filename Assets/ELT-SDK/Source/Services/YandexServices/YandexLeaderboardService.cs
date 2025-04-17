using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using ELT_SDK.Source.Entities;
using ELT_SDK.Source.SDK.Services.Interfaces;
using ELT_SDK.Source.Utilities;
using Newtonsoft.Json;

namespace ELT_SDK.Source.SDK.Services.YandexServices
{
   public class YandexLeaderboardService : SingletonBehaviour<YandexLeaderboardService>, ILeaderboardService
   {
      [DllImport("__Internal")]
      private static extern void SetScoreToLeaderboardExtern(string leaderboardName, int value);

      [DllImport("__Internal")]
      private static extern void LoadLeaderboardExtern(string leaderboardName);

      private UniTaskCompletionSource<Leaderboard> _loadCompletionSource;

      public Dictionary<string, Leaderboard> Leaderboards { get; } = new();

      public void SetScoreToLeaderboard(string leaderboardName, int value) =>
         SetScoreToLeaderboardExtern(leaderboardName, value);

      public async UniTask UpdateLeaderboard(string leaderboardName)
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
         
      }
   }
}