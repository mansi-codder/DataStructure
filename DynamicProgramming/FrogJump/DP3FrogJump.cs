using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class DP3FrogJump
    {
        //frog can jump either i+1 or i+2
        public static void main()
        {
            int[] heights = { 10, 20, 30, 10 };
            int n = 4;
            int minEnergyConsumed = FrogJumpOptimize(n - 1, heights);
            Console.WriteLine(minEnergyConsumed);
        }
        //time complexity = O(n) , space = O(1) (array)
        private static int FrogJumpOptimize(int n, int[] heights)
        {
            int prev1 = 0;
            int prev2 = 0;
            int current = 0;
            for (long i = 1; i < n; i++)
            {
                int left = prev1 + Math.Abs(heights[i] - heights[i - 1]);
                int right = int.MaxValue;
                if (i > 1) { right = prev2 + Math.Abs(heights[i] - heights[i - 1]); }
                current = Math.Min(left, right);
                prev2 = prev1;
                prev1 = current;
            }
            return prev1;
        }
    }
}
