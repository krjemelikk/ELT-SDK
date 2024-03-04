using System.Runtime.InteropServices;

namespace YandexSDK.Source.SDK
{
   public class YandexSDKLeaderboard : SingletonBehaviour<YandexSDKLeaderboard>
   {
      [DllImport("__Internal")]
      private static extern void SetToLeaderBoardExtern(int value, string leaderboardName);

      public void SetToLeaderBoard(int value, string leaderboardName = "leaderboard") =>
         SetToLeaderBoardExtern(value, leaderboardName);
   }
}