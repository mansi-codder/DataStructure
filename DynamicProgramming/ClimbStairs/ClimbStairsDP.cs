using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.DynamicProgramming
{
    static class ClimbStairsDP
    {
        public static void main()
        {
            long n = 10;
            long ways = ClimbStairs(n);
            Console.WriteLine(ways);
        }
        //time complexity = O(n) , space = O(n) (array)
        private static long ClimbStairs(long n)
        {
            long[] arr = new long[n + 1];
            arr[0] = 1;
            arr[1] = 1;
            for (long i = 2; i < n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[n - 1];
        }


        //time complexity = O(n) , space = O(1)
        private static long ClimbStairsOptimize(long n)
        {
            long prev1 = 1;
            long prev2 = 1;
            long current = 0;
            for (long i = 2; i < n; i++)
            {
                current = prev1 + prev2;
                prev2 = prev1;
                prev1 = current;
            }
            return prev1;
        }
    }
}
