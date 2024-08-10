using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class DP4FrogJumpKSteps
    {
        //frog can jump either i+1 or i+2
        public static void main()
        {
            int[] heights = { 15, 10, 22, 35, 11, 44, 29, 7 };
            int n = heights.Length,  k=3;
            int minEnergyConsumed = FrogJumpTabulation(n - 1,k, heights);
            Console.WriteLine(minEnergyConsumed);
        }
        //Complexity Analysis
        // Time Complexity: O(N* K)
       //Reason: We are running two nested loops, where outer loops run from 1 to n-1 and the inner loop runs from 1 to K
        //Space Complexity: O(N)
        //Reason: We are using an external array of size ‘n’’.
        private static int FrogJumpTabulation(int n,int k, int[] heights)
        {
            if (n == 0) return 0;
            int[] dp = new int[n];
            dp[0] = 0; 
            dp[1] = Math.Abs(heights[1] - heights[0]);
            for (long i = 2; i < n; i++)
            {
                int min = int.MaxValue;
                for (int j = 1; j <= k; j++)
                {
                    if (i - j >= 0)
                    {
                        int jump = dp[i - j] + Math.Abs(heights[i] - heights[i - j]);
                        min = Math.Min(min, jump);
                    }
                }
                dp[i] = min;
            }
            Console.WriteLine($" list of size K: {k} and energy at every step : " + string.Join(",", dp));
            return dp[n-1];
        }
    }
}
