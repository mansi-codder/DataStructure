
# Solving the Frog Jump Problem with Energy Consumption in C#: Recursive and Tabulation Approaches

The Frog Jump problem is a classic dynamic programming problem where a frog can jump either 1 or 2 steps at a time, and each step has an associated energy cost. The goal is to find the minimum energy required for the frog to reach the end of the path. In this article, we'll explore two methods to solve this problem in C#: using recursion and tabulation. We'll also analyze the time and space complexity of each approach.

## Problem Statement

Given an array of integers where each element represents the energy cost to step on that stone, find the minimum energy required for the frog to reach the last stone. The frog can jump either 1 or 2 steps at a time.

For example, given the array

`[10, 30, 40, 20]`

, the minimum energy required is `30`

 (10 -> 30 -> 20).

## Recursive Approach

The recursive approach involves making a choice at each stone: either jump 1 step or 2 steps, and recursively calculate the minimum energy required for each choice.

### Pseudo-Code

**Raw code**

``<div class="MuiBox-root css-13s85fp"><code node="[object Object]">`function MinEnergy(arr, index):
    if index == 0:
        return 0
    if index == 1:
        return abs(arr[1] - arr[0])
    if index in memo:
        return memo[index]

    jumpOne = MinEnergy(arr, index - 1) + abs(arr[index] - arr[index - 1])
    jumpTwo = MinEnergy(arr, index - 2) + abs(arr[index] - arr[index - 2])

    memo[index] = min(jumpOne, jumpTwo)
    return memo[index]`</code></div>``

### C# Code

**csharp**

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] arr = { 10, 30, 40, 20 };
        Dictionary<int, int> memo = new Dictionary<int, int>();
        int result = MinEnergy(arr, arr.Length - 1, memo);
        Console.WriteLine("Minimum Energy using recursion: " + result);
    }

    static int MinEnergy(int[] arr, int index, Dictionary<int, int> memo)
    {
        if (index == 0)
        {
            return 0;
        }

        if (index == 1)
        {
            return Math.Abs(arr[1] - arr[0]);
        }

        if (memo.ContainsKey(index))
        {
            return memo[index];
        }

        int jumpOne = MinEnergy(arr, index - 1, memo) + Math.Abs(arr[index] - arr[index - 1]);
        int jumpTwo = MinEnergy(arr, index - 2, memo) + Math.Abs(arr[index] - arr[index - 2]);

        memo[index] = Math.Min(jumpOne, jumpTwo);
        return memo[index];
    }
}
```

### Recursion Tree

To better understand the recursive approach, let's visualize the recursion tree for the array

`[10, 30, 40, 20]`

.

**Raw code**

    Min(arr, 3)
				  /    \
                  Min(arr, 2)                 Min(arr, 1)
		   /      \                              |
Min(arr, 1)         Min(arr, 0)
   |           			   |
Min(arr, 0)  		  0
   |
   0

In this tree:

* Each node represents a call to
  `MinEnergy`
  with a specific index.
* The left child represents the choice of jumping 1 step.
* The right child represents the choice of jumping 2 steps.
* The base cases are when
  `index == 0`
  or `index == 1`
  .

### Time Complexity

The time complexity of this approach is (O(n)) due to memoization, which ensures that each subproblem is solved only once.

### Space Complexity

The space complexity is (O(n)) for the memoization dictionary and (O(n)) for the recursion stack, leading to a total space complexity of (O(n)).

## Tabulation Approach

The tabulation approach uses a bottom-up dynamic programming technique to iteratively build the solution.

### Pseudo-Code

**Raw code**

``<div class="MuiBox-root css-13s85fp"><code node="[object Object]">`function MinEnergy(arr):
    if length of arr is 0:
        return 0
    if length of arr is 1:
        return 0

    dp = array of size length of arr
    dp[0] = 0
    dp[1] = abs(arr[1] - arr[0])

    for i from 2 to length of arr - 1:
        jumpOne = dp[i-1] + abs(arr[i] - arr[i-1])
        jumpTwo = dp[i-2] + abs(arr[i] - arr[i-2])
        dp[i] = min(jumpOne, jumpTwo)

    return dp[length of arr - 1]`</code></div>``

### C# Code

**csharp**

```csharp
using System;

class Program
{
    static void Main()
    {
        int[] arr = { 10, 30, 40, 20 };
        int result = MinEnergy(arr);
        Console.WriteLine("Minimum Energy using tabulation: " + result);
    }

    static int MinEnergy(int[] arr)
    {
        if (arr.Length == 0)
        {
            return 0;
        }

        if (arr.Length == 1)
        {
            return 0;
        }

        int[] dp = new int[arr.Length];
        dp[0] = 0;
        dp[1] = Math.Abs(arr[1] - arr[0]);

        for (int i = 2; i < arr.Length; i++)
        {
            int jumpOne = dp[i - 1] + Math.Abs(arr[i] - arr[i - 1]);
            int jumpTwo = dp[i - 2] + Math.Abs(arr[i] - arr[i - 2]);
            dp[i] = Math.Min(jumpOne, jumpTwo);
        }

        return dp[arr.Length - 1];
    }
}
```

### Tabulation Visualization

To better understand the tabulation approach, let's visualize how the

`dp` array is filled for the array `[10, 30, 40, 20]`

1. Initialize
   `dp` array:

   ```yaml
   dp = [0, 20, _, _]
   ```
2. Fill
   `dp` array

   For  `i = 2`

   * ```yaml
     jumpOne = dp[1] + abs(arr[2] - arr[1]) = 20 + 10 = 30
     jumpTwo = dp[0] + abs(arr[2] - arr[0]) = 0 + 30 = 30
     dp[2] = min(30, 30) = 30
     dp = [0, 20, 30, _]
     ```
   * For  `i = 3`

   ```yaml
   jumpOne = dp[2] + abs(arr[3] - arr[2]) = 30 + 20 = 50 
   jumpTwo = dp[1] + abs(arr[3] - arr[1]) = 20 + 10 = 30 
   dp[3] = min(50, 30) = 30 dp = [0, 20, 30, 30] 
   ```
3. Final
   `dp` array:

   ```yaml
   dp = [0, 20, 30, 30] 
   ```

### Time Complexity

The time complexity of this approach is (O(n)) because we iterate through the array once.

### Space Complexity

The space complexity is (O(n)) due to the storage of the `dp` array.

## Conclusion

Both the recursive and tabulation approaches effectively solve the Frog Jump problem with energy consumption. While they share the same time complexity of (O(n)), the tabulation approach is generally more space-efficient as it avoids the overhead of the recursion stack.
