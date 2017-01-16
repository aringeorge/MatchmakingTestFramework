using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchmakingTestFramework.Utils;

namespace MatchmakingTestFramework.Player
{
   class Player
   {
      public short ID { get; set; }

      public Player()
      {
         ID = RandHelper.Rand16();
      }
   }
}
