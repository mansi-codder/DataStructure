using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   static class CanCrossDP
    {
        public static void main()
        {
            //int[] stones = { 0, 1, 3, 5, 6, 8, 12, 17 };
            //int[] stones = { 0, 2 };
            int[] stones = { 0, 1, 2, 3, 4, 8, 9, 11 };

            bool canCross = CanCrossBridgeDP(stones);
        }

        public static bool CanCrossBridgeDP(int[] stones) {
            if (stones.Length == 1) return true;
            else if (stones.Length > 1 && stones[1] - stones[0] != 1 ) {
                return false;
            }

            int k = 1;

            for (int i = 1; i < stones.Length; i++)
            {
                int j = i + 1;
                while( j < stones.Length)
                {
                    int units = stones[j] - stones[j - 1];
                    if (units == k || units == k - 1 || units == k + 1)
                    {
                        j++;
                        k = units;
                    }
                    else
                        break;
                }
                if (j == stones.Length) return true;
            }
            return false;
        }

        
    }
}
