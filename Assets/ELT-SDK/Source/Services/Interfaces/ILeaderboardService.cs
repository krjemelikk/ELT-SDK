using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ELT_SDK.Source.Entities;

namespace ELT_SDK.Source.SDK.Services.Interfaces
{
   public interface ILeaderboardService
   {
      Dictionary<string, Leaderboard> Leaderboards { get; }
      void SetScoreToLeaderboard(string leaderboardName, int value);
      UniTask UpdateLeaderboard(string leaderboardName);
   }
}