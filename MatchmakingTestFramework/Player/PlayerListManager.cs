using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatchmakingTestFramework.Player
{
   static class PlayerListManager
   {
      private static Dictionary<long, PlayerGroup> mConnectedPartiesOfPlayers;

      public static void Initialize()
      {
         mConnectedPartiesOfPlayers = new Dictionary<long, PlayerGroup>();
      }

      public static void AddGroups(int count)
      {
         for (int i = 0; i < count; i++)
         {
            PlayerGroup grp = new PlayerGroup(PlayerCreator.CreatePlayerGroup());
            mConnectedPartiesOfPlayers.Add(grp.ID, grp);
         }
      }

      public static int TotalGroupCount
      {
         get
         {
            return mConnectedPartiesOfPlayers.Count;
         }
      }

      public static int GroupCountInState(GroupState state)
      {
         return mConnectedPartiesOfPlayers.Count(x => x.Value.State == state);
      }

      public static List<PlayerGroup> GroupListInState(GroupState state)
      {
         return mConnectedPartiesOfPlayers.Where(x => x.Value.State == state).Select(x => x.Value).ToList();
      }

      public static void ModifyGroupState(long groupID, GroupState state)
      {
         if (mConnectedPartiesOfPlayers.ContainsKey(groupID) == true)
         {
            mConnectedPartiesOfPlayers[groupID].State = state;
         }
      }

      public static List<PlayerGroup> GroupList
      {
         get
         {
            return mConnectedPartiesOfPlayers.Select(x => x.Value).ToList();
         }
      }

      public static void RemoveExistingGroup(long groupID)
      {
         mConnectedPartiesOfPlayers.Remove(groupID);
      }
   }
}
