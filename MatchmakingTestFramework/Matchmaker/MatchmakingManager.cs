using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MatchmakingTestFramework.Player;

namespace MatchmakingTestFramework.Matchmaker
{
   static class MatchmakingManager
   {
      public static int INITIAL_MATCHMAKING_RATING = 100;

      private static bool mRunning;
      private static Thread mMatchmakerThread;
      private static Matchmaker mMatchmaker;

      public static void Initialize()
      {
         mMatchmaker = new Matchmaker();

         ThreadStart threadStart = new ThreadStart(MatchmakerThread);
         mMatchmakerThread = new Thread(threadStart);

         mRunning = true;
         mMatchmakerThread.Start();
      }

      private static void MatchmakerThread()
      {
         while (mRunning == true)
         {
            List<PlayerGroup> playersWaitingToMatchmake = PlayerListManager.GroupListInState(GroupState.WaitingToMatchmake);
            mMatchmaker.StartMatchmaking(playersWaitingToMatchmake);
            Thread.Sleep(100);
         }
      }
   }
}
