using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class DP5maximumNonAdjacentSumOptimize
    {
        public static int MaximumNonAdjacentSum(List<int> nums)
        {
            int n = nums.Count;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = -1;
            }
            return Solve(nums, dp);
        }

        private static int Solve(List<int> nums, int[] dp)
        {
            int n = dp.Length;
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Count; i++)
            {
                int pick = nums[i] + dp[i - 2];
                int notPick = dp[i - 1];

                dp[i] = Math.Max(pick, notPick);
            }
            return dp[n - 1];
        }

        public static void main()
        {
            List<int> nums = new List<int> { 4, 8 };
            Console.WriteLine(MaximumNonAdjacentSum(nums)); // Output: 13 (3 + 10)
        }
    }
}
