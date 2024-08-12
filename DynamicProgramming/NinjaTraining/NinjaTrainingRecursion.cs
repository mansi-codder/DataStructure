   using System;

    class NinjaTrainingRecursion
    {
        // Recursive function to calculate the maximum points for the ninja training
        static int F(int day, int last, int[,] points, int[,] dp)
        {
            // If the result is already calculated, return it
            if (dp[day, last] != -1) return dp[day, last];

            // Base case: When it's the first day (day == 0)
            if (day == 0)
            {
                int maxi = 0;
                for (int i = 0; i <= 2; i++)
                {
                    if (i != last)
                        maxi = Math.Max(maxi, points[0, i]);
                }
                return dp[day, last] = maxi; // Store and return the result
            }

            int maxPoints = 0;
            // Loop through the three activities on the current day
            for (int i = 0; i <= 2; i++)
            {
                if (i != last)
                {
                    // Calculate the points for the current activity and recursively
                    // calculate the maximum points for the previous day
                    int activity = points[day, i] + F(day - 1, i, points, dp);
                    maxPoints = Math.Max(maxPoints, activity); // Update the maximum points
                }
            }

            return dp[day, last] = maxPoints; // Store and return the result
        }

        // Function to find the maximum points for ninja training
        static int NinjaTraining(int n, int[,] points)
        {
            // Initialize a memoization table with -1 values
            int[,] dp = new int[n, 4];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dp[i, j] = -1;
                }
            }

            // Start the recursive calculation from the last day (n - 1) with the last activity (3)
            return F(n - 1, 3, points, dp);
        }

        public static void main()
        {
            // Define the points for each activity on each day
            int[,] points = {
            { 10, 40, 70 },
            { 20, 50, 80 },
            { 30, 60, 90 }
        };

            int n = points.GetLength(0); // Get the number of days
            Console.WriteLine(NinjaTraining(n, points)); // Calculate and print the maximum points
        }
    }