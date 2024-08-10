using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
     static class PrintAllSubSequenceRecursion
    {
        public static List<List<int>> GenerateSubsequences(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            List<int> current = new List<int>();
            GenerateSubsequencesHelper(nums, 0, current, result);
            return result;
        }

        /// <summary>
        /// Recursive Approach:
        //We use a helper function GenerateSubsequencesHelper that takes the current index, the current subsequence being built, and the result list.
        //At each step, we either include the current element in the subsequence or exclude it, and recursively call the helper function for the next index.
        //When we reach the end of the array (base case), we add the current subsequence to the result list.
        ///// </summary>
       
        private static void GenerateSubsequencesHelper(int[] nums, int index, List<int> current, List<List<int>> result)
        {
            if (index == nums.Length)
            {
                result.Add(new List<int>(current));
                return;
            }

            // Include the current element
            current.Add(nums[index]);
            GenerateSubsequencesHelper(nums, index + 1, current, result);

            // Exclude the current element
            current.RemoveAt(current.Count - 1);
            GenerateSubsequencesHelper(nums, index + 1, current, result);
        }

        public static void GenerateSubsequences()
        {
            int[] nums = { 1, 2, 3 };
            List<List<int>> subsequences = GenerateSubsequences(nums);

            foreach (var subsequence in subsequences)
            {
                Console.WriteLine(string.Join(", ", subsequence));
            }
        }
    }
}
