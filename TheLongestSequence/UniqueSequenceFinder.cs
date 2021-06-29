using System;
using System.Collections.Generic;

namespace TheLongestSequence
{
    /// <summary>
    /// Сontains methods for finding the longest subsequence in an input string
    /// </summary>
    public static class UniqueSequenceFinder
    {
        /// <summary>
        /// Selects different subsequences of unique
        /// characters in input sequence
        /// </summary>
        /// <param name="inputSequence"></param>
        /// <returns>Length of the longest unique subsequence</returns>
        public static int GetTheLongestUniqueSubsequenceLength(this string inputSequence) 
        {
            if(inputSequence is null)
            {
                throw new ArgumentException();
            }
            int logestSubsequenceLength = 0;
            int currentSubsequenceLength = 0;
            for (int i = 0; i < inputSequence.Length; i++)
            {
                currentSubsequenceLength = GetSubstringLength(inputSequence.Substring(i));
                if (currentSubsequenceLength > logestSubsequenceLength)
                {
                    logestSubsequenceLength = currentSubsequenceLength;
                }
            }
            return logestSubsequenceLength;
        }


        /// <summary>
        /// Selects a subsequence of non-repeating characters from input string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Length of the first subsequence</returns>
        public static int GetSubstringLength(string input)
        {
            int subsequenceLength = 0;
            Dictionary<char, bool> map = new Dictionary<char, bool>();

            foreach (char currentChar in input)
            {
                if (map.Count != 0 && map.TryGetValue(currentChar, out bool value))
                {
                    return subsequenceLength;
                }

                subsequenceLength++;
                map.Add(currentChar, true);
            }

            return subsequenceLength;
        }
    }
}
