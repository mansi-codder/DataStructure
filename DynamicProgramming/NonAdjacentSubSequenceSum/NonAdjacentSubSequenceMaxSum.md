# Finding the Maximum Non-Adjacent Sum in an Array: Recursive and Tabulation Approaches

Finding the maximum sum of non-adjacent elements in an array is a classic problem that can be solved using dynamic programming techniques. In this article, we'll explore two methods to solve this problem in C#: using recursion and tabulation. We'll also analyze the time and space complexity of each approach.

## Problem Statement

Given an array of integers, find the maximum sum of non-adjacent elements. For example, given the array

`[3, 2, 5, 10, 7]`

, the maximum non-adjacent sum is `15`

 (3 + 10 + 2).

## Recursive Approach

The recursive approach involves making a choice at each element: either include the element in the sum (and skip the next element) or exclude the element and move to the next one.

### Pseudo-Code

**Raw code**

``<div class="MuiBox-root css-13s85fp"><code node="[object Object]">`function MaxNonAdjacentSum(arr, index):
    if index >= length of arr:
        return 0
    if index in memo:
        return memo[index]

    include = arr[index] + MaxNonAdjacentSum(arr, index + 2)
    exclude = MaxNonAdjacentSum(arr, index + 1)

    memo[index] = max(include, exclude)
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
        int[] arr = { 3, 2, 5, 10, 7 };
        Dictionary<int, int> memo = new Dictionary<int, int>();
        int result = MaxNonAdjacentSum(arr, 0, memo);
        Console.WriteLine("Maximum Non-Adjacent Sum using recursion: " + result);
    }

    static int MaxNonAdjacentSum(int[] arr, int index, Dictionary<int, int> memo)
    {
        if (index >= arr.Length)
        {
            return 0;
        }

        if (memo.ContainsKey(index))
        {
            return memo[index];
        }

        int include = arr[index] + MaxNonAdjacentSum(arr, index + 2, memo);
        int exclude = MaxNonAdjacentSum(arr, index + 1, memo);

        memo[index] = Math.Max(include, exclude);
        return memo[index];
    }
}
```

### Time Complexity

The time complexity of this approach is (O(n)) due to memoization, which ensures that each subproblem is solved only once.

### Space Complexity

The space complexity is (O(n)) for the memoization dictionary and (O(n)) for the recursion stack, leading to a total space complexity of (O(n)).

## Tabulation Approach

The tabulation approach uses a bottom-up dynamic programming technique to iteratively build the solution.

### Pseudo-Code

**Raw code**

``<div class="MuiBox-root css-13s85fp"><code node="[object Object]">`function MaxNonAdjacentSum(arr):
    if length of arr is 0:
        return 0
    if length of arr is 1:
        return arr[0]

    dp = array of size length of arr
    dp[0] = arr[0]
    dp[1] = max(arr[0], arr[1])

    for i from 2 to length of arr - 1:
        dp[i] = max(dp[i-1], arr[i] + dp[i-2])

    return dp[length of arr - 1]`</code></div>``

### C# Code

**csharp**

```csharp
using System;

class Program
{
    static void Main()
    {
        int[] arr = { 3, 2, 5, 10, 7 };
        int result = MaxNonAdjacentSum(arr);
        Console.WriteLine("Maximum Non-Adjacent Sum using tabulation: " + result);
    }

    static int MaxNonAdjacentSum(int[] arr)
    {
        if (arr.Length == 0)
        {
            return 0;
        }

        if (arr.Length == 1)
        {
            return arr[0];
        }

        int[] dp = new int[arr.Length];
        dp[0] = arr[0];
        dp[1] = Math.Max(arr[0], arr[1]);

        for (int i = 2; i < arr.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1], arr[i] + dp[i - 2]);
        }

        return dp[arr.Length - 1];
    }
}
```

### Time Complexity

The time complexity of this approach is (O(n)) because we iterate through the array once.

### Space Complexity

The space complexity is (O(n)) due to the storage of the

`dp`

 array.

## Conclusion

Both the recursive and tabulation approaches effectively solve the problem of finding the maximum sum of non-adjacent elements in an array. While they share the same time complexity of (O(n)), the tabulation approach is generally more space-efficient as it avoids the overhead of the recursion stack.
