# Solving the Climb Stairs Problem in C#: Recursive and Tabulation Approaches

The Climb Stairs problem is a classic dynamic programming problem where you need to find the number of ways to reach the top of a staircase with `n` steps. You can either take 1 step or 2 steps at a time. In this article, we'll explore two methods to solve this problem in C#: using recursion and tabulation. We'll also analyze the time and space complexity of each approach.

## Problem Statement

Given `n` steps, find the number of distinct ways to reach the top. You can either take 1 step or 2 steps at a time.

For example, if `n = 3`, the number of ways to reach the top is `3`  (1+1+1, 1+2, 2+1).

## Recursive Approach

The recursive approach involves making a choice at each step: either take 1 step or 2 steps, and recursively calculate the number of ways to reach the top from each choice.

### Pseudo-Code

```yaml
function ClimbStairs(n):
    if n == 0 or n == 1:
        return 1
    if n in memo:
        return memo[n]  
    oneStep = ClimbStairs(n - 1)
    twoSteps = ClimbStairs(n - 2)  
    memo[n] = oneStep + twoSteps
    return memo[n]

```

### C# Code

**csharp**

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = 5;
        Dictionary<int, int> memo = new Dictionary<int, int>();
        int result = ClimbStairs(n, memo);
        Console.WriteLine("Number of ways to climb stairs using recursion: " + result);
    }

    static int ClimbStairs(int n, Dictionary<int, int> memo)
    {
        if (n == 0 || n == 1)
        {
            return 1;
        }

        if (memo.ContainsKey(n))
        {
            return memo[n];
        }

        int oneStep = ClimbStairs(n - 1, memo);
        int twoSteps = ClimbStairs(n - 2, memo);

        memo[n] = oneStep + twoSteps;
        return memo[n];
    }
}
```

### Recursion Tree

To better understand the recursive approach, let's visualize the recursion tree for `n = 3`

    ClimbStairs(3)
 		                /
          ClimbStairs(2)              ClimbStairs(1)
                 /     \                            |

ClimbStairs(1)   ClimbStairs(0)
   |                            |
   1                          1

In this tree:

* Each node represents a call to
  `ClimbStairs`
  with a specific `n`
  .
* The left child represents the choice of taking 1 step.
* The right child represents the choice of taking 2 steps.
* The base cases are when
  `n == 0`
  or `n == 1`
  .

### Time Complexity

The time complexity of this approach is (O(n)) due to memoization, which ensures that each subproblem is solved only once.

### Space Complexity

The space complexity is (O(n)) for the memoization dictionary and (O(n)) for the recursion stack, leading to a total space complexity of (O(n)).

## Tabulation Approach

The tabulation approach uses a bottom-up dynamic programming technique to iteratively build the solution.

### Pseudo-Code

**Raw code**

```yaml
function ClimbStairs(n):
    if n == 0 or n == 1:
        return 1    dp = array of size n + 1
    dp[0] = 1
    dp[1] = 1  
    for i from 2 to n:
        dp[i] = dp[i-1] + dp[i-2]  
    return dp[n]
```



### C# Code

**csharp**

```csharp
using System;

class Program
{
    static void Main()
    {
        int n = 5;
        int result = ClimbStairs(n);
        Console.WriteLine("Number of ways to climb stairs using tabulation: " + result);
    }

    static int ClimbStairs(int n)
    {
        if (n == 0 || n == 1)
        {
            return 1;
        }

        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }
}
```

### Tabulation Visualization

To better understand the tabulation approach, let's visualize how the

`dp`

 array is filled for `n = 5`

1. Initialize

   ```yaml
   dp = [1, 1, _, _, _, _]
   ```
2. Fill For `i = 2`

   ```yaml
   dp[2] = dp[1] + dp[0] = 1 + 1 = 2
   dp = [1, 1, 2, _, _, _
   ```

   For `i = 3`

   ```yaml
   dp[3] = dp[2] + dp[1] = 2 + 1 = 3 dp = [1, 1, 2, 3, _, _] 
   ```

   For  `i = 4`

   ```yaml
   dp[4] = dp[3] + dp[2] = 3 + 2 = 5 dp = [1, 1, 2, 3, 5, _] 
   ```

   For `i = 5`

   ```yaml
   `dp[5] = dp[4] + dp[3] = 5 + 3 = 8 dp = [1, 1, 2, 3, 5, 8] `
   ```
3. Final  `dp` array:

   ```yaml
   dp = [1, 1, 2, 3, 5, 8]
   ```

### Time Complexity

The time complexity of this approach is (O(n)) because we iterate through the array once.

### Space Complexity

The space complexity is (O(n)) due to the storage of the `dp` array.

## Conclusion

Both the recursive and tabulation approaches effectively solve the Climb Stairs problem. While they share the same time complexity of (O(n)), the tabulation approach is generally more space-efficient as it avoids the overhead of the recursion stack.
