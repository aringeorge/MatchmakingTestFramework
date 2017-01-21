using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchmakingTestFramework.Matchmaker
{
   class MatchmakingRating
   {
      public decimal Rating { get; set; }
      public int TotalMatchWins { get; set; }
      public int TotalMatchLoss { get; set; }
      
      public int CurrentWinLossStreak { get; set; }
   }
}
