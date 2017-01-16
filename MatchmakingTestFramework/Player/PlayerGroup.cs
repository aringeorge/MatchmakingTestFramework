using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchmakingTestFramework.Utils;

namespace MatchmakingTestFramework.Player
{
   enum GroupState
   {
      Connected = 0,
      WaitingToMatchmake = 1,
      MatchFound = 2,
      PlayingGame = 3,
      Disconnected = 4,
   }

   class PlayerGroup
   {
      public DateTime TimeConnected { get; private set; }
      public DateTime TimeMatchmakingStart { get; private set; }
      public DateTime TimeMatchFound { get; private set; }
      public DateTime TimePlayingGameStart { get; private set; }
      public DateTime TimeDisconnect { get; private set; }

      private long GroupID;
      private List<Player> PlayersInGroup;
      private GroupState CurrentGroupState;

      public PlayerGroup(List<Player> players)
      {
         GroupID = RandHelper.Rand64();
         PlayersInGroup = players;
         State = GroupState.Connected;
      }

      public long ID
      {
         get
         {
            return GroupID;
         }
      }

      public int Count
      {
         get
         {
            return PlayersInGroup.Count;
         }
      }

      public List<Player> AllPlayers
      {
         get
         {
            return PlayersInGroup;
         }
      }

      public List<short> PlayerIDs
      {
         get
         {
            return PlayersInGroup.Select(x => x.ID).ToList();
         }
      }

      public GroupState State
      {
         get
         {
            return CurrentGroupState;
         }
         set
         {
            CurrentGroupState = value;
            switch (CurrentGroupState)
            {
               case GroupState.Connected:
                  TimeConnected = DateTime.UtcNow;
                  break;
               case GroupState.WaitingToMatchmake:
                  TimeMatchmakingStart = DateTime.UtcNow;
                  break;
               case GroupState.MatchFound:
                  TimeMatchFound = DateTime.UtcNow;
                  break;
               case GroupState.PlayingGame:
                  TimePlayingGameStart = DateTime.UtcNow;
                  break;
               case GroupState.Disconnected:
                  TimeDisconnect = DateTime.UtcNow;
                  break;

            }
         }
      }
   }
}
