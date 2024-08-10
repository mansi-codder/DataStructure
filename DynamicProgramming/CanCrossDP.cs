using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   static class CanFrogCrossRecursion
    {
        public static void main()
        {
            //int[] stones = { 0, 1, 3, 5, 6, 8, 12, 17 };
            int[] stones = { 0, 2 };
            // Dictionary to store the possible jumps from each stone
            int n = stones.Length;
            int[,] dp = new int[n, n];

            // Initialize the dictionary with each stone
            
            bool canCross = CanFrogCrossBridge(stones,dp);
        }

        public static bool CanFrogCrossBridge(int[] stones, int[,] dp) {

            if (stones.Length == 1) return true;
            else if (stones.Length > 1 && stones[1] - stones[0] != 1)
            {
                return false;
            }

            return CanFrogCross(stones, 1, 1, dp);
        }
        public static bool CanFrogCross(int[] stones, int jump, int index, int[,] dp)
        {
            if (jump == 0) return false;
            if (index == stones.Length-1) return true;
            int k = jump;

            for (int i = k - 1; i <= k + 1; i++)
            {
                int newIndex = Possible(stones, i, index,dp);
                if (newIndex > 0){
                    Console.WriteLine(newIndex);
                    if (CanFrogCross(stones, i, newIndex, dp))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static int Possible( int[] stones, int jump, int index, int[,] dp)
        {
            if (dp[index, jump] == 0)
            {
                int nextIndex = 0;
                if (jump == 0) return 0;

                for (int i = index + 1; i < stones.Length; i++)
                {
                    if (stones[i] == stones[index] + jump)
                    {
                        nextIndex = i;
                        dp[index, jump] = nextIndex;
                        break;
                    }
                }
            }
            return dp[index, jump];
        }
    }
}
