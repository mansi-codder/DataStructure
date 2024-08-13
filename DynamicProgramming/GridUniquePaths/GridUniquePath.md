# Exploring Unique Paths in a Grid: Dynamic Programming and Recursion Approaches

In this article, we will explore three different approaches to solve the problem of finding unique paths in a grid. We will discuss two dynamic programming (DP) approaches and one recursive approach. Each approach will be explained step-by-step with detailed comments on the code, including space and time optimization considerations.

## Problem Statement

Given a grid of size `M x N`, you are initially positioned at the top-left corner of the grid (i.e., at `(0, 0)`). Your goal is to reach the bottom-right corner of the grid (i.e., at `(M-1, N-1)`). You can only move either down or right at any point in time. Determine the number of unique paths to reach the bottom-right corner.

## Approach 1: Dynamic Programming with 2D Array

### C# Implementation

```csharp
using System;

public class GidUniquePathDP
{
    public const int M = 3; // Number of rows
    public const int N = 3; // Number of columns

    public static void Main()
    {
        int[,] dp = new int[M, N]; // Initialize a 2D array to store the number of paths
        dp[0, 0] = 1; // Base case: starting point

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (dp[i, j] != 1)
                {
                    int up = i > 0 ? dp[i - 1, j] : 0; // Paths from the cell directly above
                    int left = j > 0 ? dp[i, j - 1] : 0; // Paths from the cell directly to the left
                    dp[i, j] = up + left; // Sum of paths from above and left
                }
            }
        }

        Console.WriteLine(dp[M - 1, N - 1]); // Output the number of unique paths to the bottom-right corner
    }
}

/*
 * Time Complexity: O(M * N)
 * - We iterate through each cell of the MxN grid exactly once.
 * - The time complexity is linear with respect to the number of cells in the grid.

 * Space Complexity: O(M * N)
 * - We use a 2D array of size MxN to store the number of paths for each cell.
 */
```

### Approach 2: Dynamic Programming with 1D Array

### C# Implementation

```csharp
using System;

public class GidUniquePathDP
{
    public const int M = 3; // Number of rows
    public const int N = 3; // Number of columns

    public static void Main()
    {
        int[] prev = new int[N]; // Initialize an array to store the previous row values
        int[] dp = new int[N]; // Initialize an array to store the current row values
        prev[0] = 1; // Base case: starting point
        dp[0] = 1; // Base case: starting point

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                int up = prev[j]; // Paths from the cell directly above
                int left = j > 0 ? dp[j - 1] : 0; // Paths from the cell directly to the left
                dp[j] = up + left; // Sum of paths from above and left
            }
            prev = (int[])dp.Clone(); // Use Clone to create a copy of the dp array
        }

        Console.WriteLine(dp[N - 1]); // Output the number of unique paths to the bottom-right corner
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
```

## Approach 3: Recursion with Memoization

### C# Implementation

```csharp
using System;

public class GidUniquePathDP
{
    public const int M = 3; // Number of rows
    public const int N = 3; // Number of columns

    public static void Main()
    {
        int[,] dp = new int[M, N]; // Initialize a 2D array to store the number of paths
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                dp[i, j] = -1; // Initialize all cells with -1 to indicate uncomputed values
            }
        }
        int newWays = GridUniquePathUpLeft(M - 1, N - 1, dp); // Calculate the number of unique paths
        Console.WriteLine(newWays); // Output the number of unique paths to the bottom-right corner
    }

    private static int GridUniquePathUpLeft(int i, int j, int[,] dp)
    {
        if (i < 0 || j < 0) return 0; // Base case: out of bounds
        if (i == 0 && j == 0) return 1; // Base case: starting point

        if (dp[i, j] != -1) return dp[i, j]; // Return the precomputed value if available

        int left = GridUniquePathUpLeft(i, j - 1, dp); // Paths from the cell directly to the left
        int up = GridUniquePathUpLeft(i - 1, j, dp); // Paths from the cell directly above
        dp[i, j] = left + up; // Sum of paths from above and left

        return dp[i, j]; // Return the computed value
    }
}

/*
 * Time Complexity: O(M * N)
 * - Each cell is computed once and stored in the dp array.
 * - The time complexity is linear with respect to the number of cells in the grid.

 * Space Complexity: O(M * N)
 * - We use a 2D array of size MxN to store the number of paths for each cell.
 * - Additionally, the recursion stack can go as deep as M + N in the worst case.
 */
```

## Conclusion

In this article, we explored three different approaches to solve the problem of finding unique paths in a grid. We discussed two dynamic programming approaches (one using a 2D array and another using a 1D array) and one recursive approach with memoization. Each approach has its own advantages and trade-offs in terms of space and time complexity. By understanding these approaches, you can choose the one that best fits your specific use case and constraints.
