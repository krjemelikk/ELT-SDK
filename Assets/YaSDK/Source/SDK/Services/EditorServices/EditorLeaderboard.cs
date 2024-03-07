using UnityEngine;
using YaSDK.Source.SDK.Interfaces;

namespace YaSDK.Source.SDK.EditorServices
{
   internal class EditorLeaderboard : ILeaderboardService
   {
      public void SetToLeaderBoard(int value, string leaderboardName) =>
         Debug.Log($"<color=blue>Leaderboard: </color>Value - {value} added to leaderboard - {leaderboardName}");
   }
}