using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class PrintAllSubSequenceDP
    {
        public static List<List<int>> GenerateSubsequences(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            result.Add(new List<int>()); // Start with an empty subsequence

            foreach (int num in nums)
            {
                int currentSize = result.Count;
                for (int i = 0; i < currentSize; i++)
                {
                    List<int> newSubsequence = new List<int>(result[i]);
                    newSubsequence.Add(num);
                    result.Add(newSubsequence);
                }
            }

            return result;
        }

        public static void main()
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
