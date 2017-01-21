using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchmakingTestFramework.Utils;

namespace MatchmakingTestFramework.Player
{
   static class PlayerCreator
   {
      public static ushort MaximumPartySize { get; set; } = 5;

      public static List<Player> CreatePlayerGroup()
      {
         List<Player> listOfPlayers = new List<Player>();
         ushort rand = (ushort)RandHelper.Rand16();
         rand = (ushort)(rand % MaximumPartySize);
         rand++;
         for (ushort i=0; i<rand; i++)
         {
            Player p = new Player();
            listOfPlayers.Add(p);
         }
         return listOfPlayers;
      }
   }
}
