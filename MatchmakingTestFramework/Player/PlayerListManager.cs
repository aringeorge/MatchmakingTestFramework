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
      private static Dictionary<long, PlayerGroup> ConnectedPartiesOfPlayers;

      public static void Initialize()
      {
         ConnectedPartiesOfPlayers = new Dictionary<long, PlayerGroup>();
      }

      public static void AddGroups(int count)
      {
         for (int i = 0; i < count; i++)
         {
            PlayerGroup grp = new PlayerGroup(PlayerCreator.CreatePlayerGroup());
            ConnectedPartiesOfPlayers.Add(grp.ID, grp);
         }
      }

      public static int TotalGroupCount
      {
         get
         {
            return ConnectedPartiesOfPlayers.Count;
         }
      }

      public static int GroupCountInState(GroupState state)
      {
         return ConnectedPartiesOfPlayers.Count(x => x.Value.State == state);
      }

      public static List<PlayerGroup> GroupListInState(GroupState state)
      {
         return ConnectedPartiesOfPlayers.Where(x => x.Value.State == state).Select(x => x.Value).ToList();
      }

      public static void ModifyGroupState(long groupID, GroupState state)
      {
         if (ConnectedPartiesOfPlayers.ContainsKey(groupID) == true)
         {
            ConnectedPartiesOfPlayers[groupID].State = state;
         }
      }

      public static List<PlayerGroup> GroupList
      {
         get
         {
            return ConnectedPartiesOfPlayers.Select(x => x.Value).ToList();
         }
      }

      public static void RemoveExistingGroup(long groupID)
      {
         ConnectedPartiesOfPlayers.Remove(groupID);
      }
   }
}
