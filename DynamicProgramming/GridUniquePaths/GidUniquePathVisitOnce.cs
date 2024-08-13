using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class GidUniquePathVisitOnce
    {
        public const int M = 3;
        public const int N = 3;
        public static void main()
        {
            int[,] arr = new int[M, N];

            int ways = find(arr, 0, 0);
        }

        private static int find(int[,] arr, int i, int j)
        {
            int down = 0;
            int right = 0;
            if ((i == M-1 && j == N - 1))
                return 1;
            
            arr[i, j] = -1;
            if (j + 1 < N && arr[i, j + 1] == 0)
            {
                right = find(arr, i, j + 1);
            }


            if (i + 1 < M && arr[i + 1, j] == 0)
            {
                down = find(arr, i + 1, j);
            }
            return right + down;
        }
    }
}
