using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MatchmakingTestFramework.Utils;

namespace MatchmakingTestFramework.Player
{
   static class PlayerClientManager
   {
      private static Thread PlayerCreatorThread;
      private static Thread PlayerDestroyThread;
      private static Thread PlayerStartMatchmakeThread;
      private static int MaximumGroupsInPlayerList;
      private static bool Running;

      public static void Initialize(int numGroups)
      {
         MaximumGroupsInPlayerList = numGroups;

         Running = true;

         PlayerCreatorThread = new Thread(PlayerCreation);
         PlayerDestroyThread = new Thread(PlayerDestruction);
         PlayerStartMatchmakeThread = new Thread(PlayerMatchmakingStartThread);
         PlayerDestroyThread.Start();
         PlayerCreatorThread.Start();
         PlayerStartMatchmakeThread.Start();
      }

      public static void Shutdown()
      {
         Running = false;
         PlayerCreatorThread.Join();
         PlayerDestroyThread.Join();
         PlayerStartMatchmakeThread.Join();
      }

      // match maker runs a thread that gets all players in the matchmaking state,
         // gets their mmr from the database system and tries to make two groups of PlayerCreator.MaximumPartySize with them and set the state to playing game
      // then then the game player will do a win / loss and calculate the mmr for the players
         // then the game player will save the players mmr into the database and set the state to disconnected

      private static void PlayerMatchmakingStartThread()
      {
         while (Running == true)
         {
            List<PlayerGroup> groupListInState = PlayerListManager.GroupListInState(GroupState.Connected);
            if (groupListInState.Count > 0)
            {
               int groupsToStartMatchmaking = RandHelper.Rand16() % groupListInState.Count + 1;
               for (int i=0; i<groupsToStartMatchmaking; i++)
               {
                  groupListInState[i].State = GroupState.WaitingToMatchmake;
               }
            }

            int msecToSleep = RandHelper.Rand16() % 200 + 100;
            Thread.Sleep(msecToSleep);
         }
      }

      private static void PlayerDestruction()
      {
         while (Running == true)
         {
            List<long> groupIDs = PlayerListManager.GroupListInState(GroupState.Disconnected).Select(x => x.ID).ToList();
            if ((groupIDs != null) && (groupIDs.Count > 0))
            {
               foreach (long id in groupIDs)
               {
                  PlayerListManager.RemoveExistingGroup(id);
               }
            }
            Thread.Sleep(1000);
         }
      }

      private static void PlayerCreation()
      {
         while (Running == true)
         {
            int totalGroupCount = PlayerListManager.TotalGroupCount;
            if (totalGroupCount < MaximumGroupsInPlayerList)
            {
               int groupsToConnect = RandHelper.Rand16() % (MaximumGroupsInPlayerList - totalGroupCount) + 1;
               PlayerListManager.AddGroups(groupsToConnect);
            }
            Thread.Sleep(1000);
         }
      }
   }
}
