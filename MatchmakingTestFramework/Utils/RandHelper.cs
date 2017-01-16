using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchmakingTestFramework.Utils
{
   static class RandHelper
   {
      private static Random mRandGen;

      public static void Initialize()
      {
         mRandGen = new Random((int)(DateTime.Now.Ticks & 0x0FFFFFFFF));
      }

      public static short Rand16()
      {
         byte[] data = new byte[sizeof(short)];
         mRandGen.NextBytes(data);
         short rand = BitConverter.ToInt16(data, 0);
         return rand;
      }

      public static long Rand64()
      {
         byte[] data = new byte[sizeof(long)];
         mRandGen.NextBytes(data);
         long rand = BitConverter.ToInt64(data, 0);
         return rand;
      }
   }
}
