using System;

public class Solution
{
    private const int COLUMNS = 3;
    private static int[,] memo;

    public static int NinjaTraining(int n, int[,] points)
    {
        memo = new int[n, COLUMNS];

        // Initialize the memo array with -1 to indicate uncomputed values
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                memo[i, j] = -1;
            }
        }

        for (int day = n - 1; day >= 0; day--)
        {
            if (day == n - 1)
            {
                memo[day, 0] = points[day, 0];
                memo[day, 1] = points[day, 1];
                memo[day, 2] = points[day, 2];
            }
            else
            {
                memo[day, 0] = points[day, 0] + Math.Max(memo[day + 1, 1], memo[day + 1, 2]);
                memo[day, 1] = points[day, 1] + Math.Max(memo[day + 1, 0], memo[day + 1, 2]);
                memo[day, 2] = points[day, 2] + Math.Max(memo[day + 1, 0], memo[day + 1, 1]);
            }
        }

        return Math.Max(memo[0, 0], Math.Max(memo[0, 1], memo[0, 2]));
    }

    public static void Main(string[] args)
    {
        // Define the points for each activity on each day
        int[,] points = {
            { 10, 40, 70 },
            { 20, 50, 80 },
            { 30, 60, 90 }
        };

        int n = points.GetLength(0); // Get the number of days
        Console.WriteLine("Maximum points: " + NinjaTraining(n, points)); // Calculate and print the maximum points
    }
}
