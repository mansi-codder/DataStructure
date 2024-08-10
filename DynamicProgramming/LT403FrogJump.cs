using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   static class LT403FrogJump
    {
        public static void main()
        {
            int[] stones = { 0, 1, 3, 5, 6, 8, 12, 17 };

            bool canCross = CanCross(stones);
        }
        public static bool CanCross(int[] stones)
        {
            if (stones.Length == 0) return false;
            if (stones[1] != 1) return false; // The first jump must be 1 unit

            // Dictionary to store the possible jumps from each stone
            Dictionary<int, HashSet<int>> dp = new Dictionary<int, HashSet<int>>();

            // Initialize the dictionary with each stone
            foreach (int stone in stones)
            {
                dp[stone] = new HashSet<int>();
            }

            // The first stone can be reached with a jump of 0 units
            dp[stones[0]].Add(0);

            for (int i = 0; i < stones.Length; i++)
            {
                int stone = stones[i];
                foreach (int jump in dp[stone])
                {
                    // Try jumps of k-1, k, and k+1 units
                    for (int k = jump - 1; k <= jump + 1; k++)
                    {
                        if (k > 0 && dp.ContainsKey(stone + k))
                        {
                            dp[stone + k].Add(k);
                        }
                    }
                }
            }

            // Check if the last stone has any possible jumps
            return dp[stones[stones.Length - 1]].Count > 0;
        }
    }
}