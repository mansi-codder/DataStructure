### Title: Mastering Ninja Training: Recursion, Memoization, and Tabulation Approaches in C#

---

In this article, we will explore different approaches to solve the Ninja Training problem using C#. We'll start with a recursive approach, enhance it with memoization, and finally, optimize it using tabulation. We'll also discuss the time and space complexities of each approach.

### Problem Statement

Given a 2D array `points` where `points[i, j]` represents the points gained by performing activity `j` on day `i`, the goal is to maximize the total points over `n` days, ensuring that the same activity is not performed on two consecutive days.

### Recursive Approach

The recursive approach involves breaking down the problem into smaller subproblems. We recursively calculate the maximum points for each day, considering the constraints.

#### Code

```csharp
public class NinjaTraining
{
    static int F(int day, int last, int[,] points)
    {
        if (day == 0)
        {
            int maxi = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (i != last)
                    maxi = Math.Max(maxi, points[0, i]);
            }
            return maxi;
        }

        int maxPoints = 0;
        for (int i = 0; i <= 2; i++)
        {
            if (i != last)
            {
                int activity = points[day, i] + F(day - 1, i, points);
                maxPoints = Math.Max(maxPoints, activity);
            }
        }

        return maxPoints;
    }

    public static void Main(string[] args)
    {
        int[,] points = {
            { 10, 40, 70 },
            { 20, 50, 80 },
            { 30, 60, 90 }
        };
        int n = points.GetLength(0);
        Console.WriteLine(F(n - 1, 3, points));
    }
}
```

#### Time Complexity

The time complexity of the recursive approach is \(O(3^n)\) because for each day, we have three choices, and we explore all possible combinations.

#### Space Complexity

The space complexity is \(O(n)\) due to the recursion stack.

### Memoization Approach

Memoization involves storing the results of subproblems to avoid redundant calculations. This significantly reduces the time complexity.

#### Code

```csharp
public class NinjaTraining
{
    static int[,] memo;

    static int F(int day, int last, int[,] points)
    {
        if (memo[day, last] != -1) return memo[day, last];

        if (day == 0)
        {
            int maxi = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (i != last)
                    maxi = Math.Max(maxi, points[0, i]);
            }
            return memo[day, last] = maxi;
        }

        int maxPoints = 0;
        for (int i = 0; i <= 2; i++)
        {
            if (i != last)
            {
                int activity = points[day, i] + F(day - 1, i, points);
                maxPoints = Math.Max(maxPoints, activity);
            }
        }

        return memo[day, last] = maxPoints;
    }

    public static void Main(string[] args)
    {
        int[,] points = {
            { 10, 40, 70 },
            { 20, 50, 80 },
            { 30, 60, 90 }
        };
        int n = points.GetLength(0);
        memo = new int[n, 4];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                memo[i, j] = -1;
            }
        }
        Console.WriteLine(F(n - 1, 3, points));
    }
}
```

#### Time Complexity

The time complexity of the memoization approach is \(O(n \times 4)\) because we store results for each day and each possible last activity.

#### Space Complexity

The space complexity is \(O(n \times 4)\) for the memoization table plus \(O(n)\) for the recursion stack.

### Tabulation Approach

Tabulation involves iteratively filling a table based on the results of subproblems. This approach eliminates the recursion stack, making it more space-efficient.

#### Code

```csharp
public class NinjaTraining
{
    public static int NinjaTraining(int n, int[,] points)
    {
        int[,] dp = new int[n, 4];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                dp[i, j] = -1;
            }
        }

        for (int day = n - 1; day >= 0; day--)
        {
            if (day == n - 1)
            {
                dp[day, 0] = points[day, 0];
                dp[day, 1] = points[day, 1];
                dp[day, 2] = points[day, 2];
            }
            else
            {
                dp[day, 0] = points[day, 0] + Math.Max(dp[day + 1, 1], dp[day + 1, 2]);
                dp[day, 1] = points[day, 1] + Math.Max(dp[day + 1, 0], dp[day + 1, 2]);
                dp[day, 2] = points[day, 2] + Math.Max(dp[day + 1, 0], dp[day + 1, 1]);
            }
        }

        return Math.Max(dp[0, 0], Math.Max(dp[0, 1], dp[0, 2]));
    }

    public static void Main(string[] args)
    {
        int[,] points = {
            { 10, 40, 70 },
            { 20, 50, 80 },
            { 30, 60, 90 }
        };
        int n = points.GetLength(0);
        Console.WriteLine(NinjaTraining(n, points));
    }
}
```

#### Time Complexity

The time complexity of the tabulation approach is \(O(n \times 3)\) because we fill the table iteratively for each day and each activity.

#### Space Complexity

The space complexity is \(O(n \times 3)\) for the table.

### Conclusion

- **Recursive Approach**: Simple but inefficient with \(O(3^n)\) time complexity.
- **Memoization Approach**: Optimized with \(O(n \times 4)\) time complexity and \(O(n \times 4)\) space complexity.
- **Tabulation Approach**: Further optimized with \(O(n \times 3)\) time complexity and \(O(n \times 3)\) space complexity.

Each approach has its use case, and understanding these techniques will help you tackle a wide range of dynamic programming problems. Happy coding!
