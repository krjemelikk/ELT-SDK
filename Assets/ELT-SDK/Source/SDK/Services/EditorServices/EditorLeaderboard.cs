using ELT_SDK.Source.SDK.Services.Interfaces;
using UnityEngine;

namespace ELT_SDK.Source.SDK.Services.EditorServices
{
   internal class EditorLeaderboard : ILeaderboardService
   {
      public void SetToLeaderBoard(int value, string leaderboardName) =>
         Debug.Log($"<color=blue>Leaderboard: </color>Value - {value} added to leaderboard - {leaderboardName}");
   }
}