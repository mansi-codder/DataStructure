using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class DP3FrogJumpMemorization
    {
        //frog can jump either i+1 or i+2
        public static void main()
        {
            int[] heights = { 10, 20, 30, 10 };
            int n = 4;
            int minEnergyConsumed = FrogJumpMemorization(n , heights);
            Console.WriteLine(minEnergyConsumed);
        }
        //time complexity = O(n) , space = O(n) (array)
       
        private static int FrogJumpMemorization(int n, int[] heights)
        {
            if (n == 0) return 0;
            int[] arr = new int[n ];
            arr[0] = 0;
            arr[1] = arr[0]+ Math.Abs(heights[1] - heights[0]);

            int current = 0;
            for (long i = 1; i < n; i++)
            {
                int left = arr[i-1] + Math.Abs(heights[i] - heights[i - 1]);
                int right = int.MaxValue;
                if (i > 1) { 
                    right = arr[i-2] + Math.Abs(heights[i] - heights[i - 2]);
                }
                current = Math.Min(left, right);
                arr[i] = current;
            }
            Console.WriteLine($"i: {1} list of size K: " + string.Join(",", arr));
            return arr[n-1];
        }
    }
}
