using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELTSDK.Source.Entities;

namespace ELTSDK.Source.Services.Interfaces
{
   public interface ILeaderboardService
   {
      Dictionary<string, Leaderboard> Leaderboards { get; }
      void SetScoreToLeaderboard(string leaderboardName, int value);
      UniTask UpdateLeaderboard(string leaderboardName);
   }
}