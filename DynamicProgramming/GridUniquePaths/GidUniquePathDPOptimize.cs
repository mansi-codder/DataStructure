using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    using System;

    public class GidUniquePathDPOptimize
    {
        // Define the dimensions of the grid
        public const int M = 3; // Number of rows
        public const int N = 3; // Number of columns

        public static void Main()
        {
            // Initialize two arrays to store the previous and current row values
            int[] prev = new int[N];
            int[] dp = new int[N];

            // Base case: starting point
            prev[0] = 1;
            dp[0] = 1;

            // Iterate through each row of the grid
            for (int i = 0; i < M; i++)
            {
                // Iterate through each column of the grid
                for (int j = 0; j < N; j++)
                {
                    // Calculate the number of unique paths to the current cell
                    int up = prev[j]; // Paths from the cell directly above
                    int left = j > 0 ? dp[j - 1] : 0; // Paths from the cell directly to the left
                    dp[j] = up + left; // Sum of paths from above and left
                }
                // Copy the current row's values to the previous row array for the next iteration
                prev = (int[])dp.Clone(); // Use Clone to create a copy of the dp array
            }

            // Output the number of unique paths to the bottom-right corner of the grid
            Console.WriteLine(dp[N - 1]);
        }
    }

    /*
     * Time Complexity: O(M * N)
     * - We iterate through each cell of the MxN grid exactly once.
     * - The time complexity is linear with respect to the number of cells in the grid.

     * Space Complexity: O(N)
     * - We use two arrays of size N to store the number of paths for the current and previous rows.
     * - This reduces the space complexity from O(M * N) to O(N) by only storing the necessary row information.
     */

}
