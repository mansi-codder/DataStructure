# Generating All Subsequences of an Array in C#: Recursive and Tabulation Approaches

Subsequences are an important concept in computer science, often used in problems related to dynamic programming, combinatorics, and more. In this article, we'll explore two methods to generate all subsequences of an array in C#: using recursion and tabulation. We'll also analyze the time and space complexity of each approach.

## Recursive Approach

The recursive approach leverages the power of recursion to generate all possible subsequences by either including or excluding each element of the array.

### Code

**csharp**

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3 };
        List<List<int>> subsequences = new List<List<int>>();
        GenerateSubsequences(arr, 0, new List<int>(), subsequences);

        Console.WriteLine("Subsequences using recursion:");
        foreach (var subsequence in subsequences)
        {
            Console.WriteLine(string.Join(", ", subsequence));
        }
    }

    static void GenerateSubsequences(int[] arr, int index, List<int> current, List<List<int>> subsequences)
    {
        if (index == arr.Length)
        {
            subsequences.Add(new List<int>(current));
            return;
        }

        // Include the current element
        current.Add(arr[index]);
        GenerateSubsequences(arr, index + 1, current, subsequences);

        // Exclude the current element
        current.RemoveAt(current.Count - 1);
        GenerateSubsequences(arr, index + 1, current, subsequences);
    }
}
```

### Time Complexity

The time complexity of this approach is (O(2^n)), where (n) is the number of elements in the array. This is because for each element, we have two choices: include it or exclude it, leading to (2^n) possible subsequences.

### Space Complexity

The space complexity is also (O(2^n)) due to the storage of all subsequences. Additionally, the recursion stack can go as deep as (O(n)).

## Tabulation Approach

The tabulation approach uses a dynamic programming technique to iteratively build subsequences.

### Code

**csharp**

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3 };
        List<List<int>> subsequences = GenerateSubsequences(arr);

        Console.WriteLine("Subsequences using tabulation:");
        foreach (var subsequence in subsequences)
        {
            Console.WriteLine(string.Join(", ", subsequence));
        }
    }

    static List<List<int>> GenerateSubsequences(int[] arr)
    {
        List<List<int>> subsequences = new List<List<int>>();
        subsequences.Add(new List<int>()); // Start with an empty subsequence

        foreach (var num in arr)
        {
            int currentSize = subsequences.Count;
            for (int i = 0; i < currentSize; i++)
            {
                List<int> newSubsequence = new List<int>(subsequences[i]);
                newSubsequence.Add(num);
                subsequences.Add(newSubsequence);
            }
        }

        return subsequences;
    }
}
```

### Time Complexity

The time complexity of this approach is also (O(2^n)). For each element, we iterate through the existing subsequences and create new ones, leading to (2^n) operations.

### Space Complexity

The space complexity is (O(2^n)) due to the storage of all subsequences. Unlike the recursive approach, there is no additional space used for the recursion stack.

## Conclusion

Both the recursive and tabulation approaches effectively generate all subsequences of an array. While they share the same time and space complexity, the choice between them can depend on the specific requirements of your application. The recursive approach is more intuitive and easier to implement for those familiar with recursion, while the tabulation approach can be more efficient in terms of space usage, as it avoids the overhead of the recursion stack.
