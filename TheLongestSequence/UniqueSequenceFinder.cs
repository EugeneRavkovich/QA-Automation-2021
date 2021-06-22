using System;
using System.Collections.Generic;

namespace TheLongestSequence
{
    public static class UniqueSequenceFinder
    {
        /// <summary>
        /// Selects the longest subsequence of non-repeating characters
        /// from input string.
        /// </summary>
        /// <param name="inputSequence"> Current string</param>
        /// <returns>Found subsequence</returns>
        public static string GetTheLongestUniqueSubsequence(this string inputSequence) 
        {
            if (string.IsNullOrEmpty(inputSequence)) 
            {
                throw new ArgumentException();
            }
            string[] subsequences = new string[inputSequence.Length];
            string maxSubsequence = string.Empty;
            int maxLength = 0;

            for (int i = 0; i < inputSequence.Length; i++)
            {
                subsequences[i] = GetSubstring(inputSequence.Substring(i));
            }

            foreach (string x in subsequences)
            {
                int currentLength = x.Length;
                if (maxLength < currentLength)
                {
                    maxLength = currentLength;
                    maxSubsequence = x;
                }
            }

            return maxSubsequence;
        }



        /// <summary>
        /// Selects a subsequence of non-repeating characters from input string
        /// </summary>
        /// <param name="input">Any string</param>
        /// <returns>Found subsequence</returns>
        public static string GetSubstring(string input)
        {
            string longestSubsequence = string.Empty;
            Dictionary<char, bool> map = new Dictionary<char, bool>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (map.Count != 0 &&
                    map.TryGetValue(currentChar, out bool value))
                {
                    return longestSubsequence;
                }

                longestSubsequence += currentChar;
                map.Add(currentChar, true);
            }

            return longestSubsequence;
        }
    }
}