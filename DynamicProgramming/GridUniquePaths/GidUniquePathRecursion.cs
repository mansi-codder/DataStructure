using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class GidUniquePathRecursion
    {
        public const int M = 3;
        public const int N = 3;
        public static void main()
        {
            int ways = findGridUniquePath(0, 0);
         
            int[,] dp = new int[M, N];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    dp[i, j] = -1;
                }
            }
            int newWays = GridUniquePathUpLeft(M - 1, N - 1, dp);
        }

        private static int findGridUniquePath(int i, int j)
        {

            if (i > M - 1 || j > N - 1) return 0;
            if ((i == M - 1 && j == N - 1))
                return 1;


            int right = findGridUniquePath(i, j + 1);
            int down = findGridUniquePath(i + 1, j);
            return right + down;
        }

        private static int GridUniquePathUpLeft(int i, int j, int[,] dp)
        {
            if (i < 0 || j < 0) return 0;
            if ((i == 0 && j == 0)) return 1;

            if (dp[i, j] != -1) return dp[i, j];

            int left = GridUniquePathUpLeft(i, j - 1, dp);
            int up = GridUniquePathUpLeft(i - 1, j, dp);
            dp[i, j] = left + up;

            return dp[i, j];
        }
    }
}
