using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   static class GidUniquePathDP
    {
        public const int M = 3;
        public const int N = 3;
        public static void main()
        {
            int[,] dp = new int[M, N];
            dp[0, 0] = 1;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (dp[i, j] != 1)
                    {
                        // current = up and left
                        int up = i > 0 ? dp[i - 1, j] : 0;
                        int down = j > 0 ? dp[i, j - 1] : 0;
                        dp[i, j] = up + down;
                    }
                }
            }

            Console.WriteLine(dp[M-1,N-1]);
        }

    }
}
