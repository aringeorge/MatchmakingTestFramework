using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchmakingTestFramework.Matchmaker;

namespace MatchmakingTestFramework.Database
{
   static class PlayerDatabase
   {
      private static Dictionary<short, MatchmakingRating> mMatchmakingPlayerDictionary;


      public static void Initialize()
      {
         mMatchmakingPlayerDictionary = new Dictionary<short, MatchmakingRating>();
      }

      public static MatchmakingRating GetPlayerMatchmakingData(short playerId)
      {
         if (mMatchmakingPlayerDictionary.ContainsKey(playerId) == true)
         {
            return mMatchmakingPlayerDictionary[playerId];
         }
         return new MatchmakingRating() { Rating = MatchmakingManager.INITIAL_MATCHMAKING_RATING; }
      }
   }
}
