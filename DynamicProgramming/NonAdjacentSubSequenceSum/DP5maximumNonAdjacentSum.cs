using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class DP5maximumNonAdjacentSum
    {
        public static int MaximumNonAdjacentSum(List<int> nums)
        {
            int n = nums.Count;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = -1;
            }
            return Solve(nums, n - 1, dp);
        }

        private static int Solve(List<int> nums, int index, int[] dp)
        {
            if (index < 0) return 0;
            if (index == 0) return nums[index];
            if (dp[index] != -1) return dp[index];

            int pick = nums[index] + Solve(nums, index - 2, dp);
            int notPick = Solve(nums, index - 1, dp);

            dp[index] = Math.Max(pick, notPick);
            return dp[index];
        }

        public static void main()
        {
            List<int> nums = new List<int> { 4,8 };
            Console.WriteLine(MaximumNonAdjacentSum(nums)); // Output: 13 (3 + 10)
        }
    }
}
