using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class DP4FrogJumpKStepsOptimize
    {
        //frog can jump either i+1 or i+2
        public static void main()
        {
            int[] heights = { 15, 10, 22, 35, 11, 44, 29, 7 };
            int n = heights.Length, k = 3;
            int minEnergyConsumed = FrogJumpTabulationOptimize(n - 1, k, heights);
            Console.WriteLine(minEnergyConsumed);
        }
        //Complexity Analysis
        // Time Complexity: O(N* K)
        //Reason: We are running two nested loops, where outer loops run from 1 to n-1 and the inner loop runs from 1 to K
        //Space Complexity: O(K)
        //Reason: We are using an external array of size ‘n’’.
        private static int FrogJumpTabulationOptimize(int n, int k, int[] heights)
        {
            if (n == 0) return 0;
            List<int> dp = new List<int>();
            dp.Add(0);
            dp.Add(Math.Abs(heights[1] - heights[0]));
            Console.WriteLine($"i: {1} list of size K: " + string.Join(",", dp));

            for (int i = 2; i < n; i++)
            {
                int min = int.MaxValue;
                int dpIndex = dp.Count - 1;
                for (int j = 1; j <= k; j++)
                {
                    if (i - j >= 0)
                    {
                        int jump = dp[dpIndex] + Math.Abs(heights[i] - heights[i - j]);
                        min = Math.Min(min, jump);
                        dpIndex--;
                    }
                }
                if (dp.Count == k)
                {
                    dp.RemoveAt(0);
                }
                dp.Add(min);
                Console.WriteLine($"i: {i} list of size K: " + string.Join(",", dp));

            }
            return dp[dp.Count - 1];
        }
    }
}
