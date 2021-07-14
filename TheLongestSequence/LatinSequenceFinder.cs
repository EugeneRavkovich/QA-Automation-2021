namespace TheLongestSequence
{
    /// <summary>
    /// Contains methods for finding the longest sequence of identical Latin letters
    /// </summary>
    public static class LatinSequenceFinder
    {
        /// <summary>
        /// Selects the longest subsequence of identical Latin letters
        /// </summary>
        /// <param name="inputSequence">Input sequence in which the search is performed</param>
        /// <returns>Length of the longest subsequence</returns>
        public static int GetTheLongestIdenticalLatinLettersSequenceLength(this string inputSequence)
        {
            if (inputSequence is null)
            {
                throw new System.ArgumentException();
            }
            if (inputSequence.Length == 0)
            {
                return 0;
            }
            char buffer = inputSequence[0];
            int longestSunsequenceLength = 0;
            int currentSubsequenceLength = 0;
            foreach (char character in inputSequence)
            {
                if (IsLatin(character) && character == buffer)
                {
                    currentSubsequenceLength++;
                }
                else if (IsLatin(character))
                {
                    if (currentSubsequenceLength > longestSunsequenceLength)
                    {
                        longestSunsequenceLength = currentSubsequenceLength;
                    }
                    currentSubsequenceLength = 1;
                    buffer = character;
                }
                else
                {
                    if (currentSubsequenceLength > longestSunsequenceLength)
                    {
                        longestSunsequenceLength = currentSubsequenceLength;
                    }
                    currentSubsequenceLength = 0;
                    buffer = character;
                }
            }
            if (currentSubsequenceLength > longestSunsequenceLength)
            {
                longestSunsequenceLength = currentSubsequenceLength;
            }
            return longestSunsequenceLength;
        }


        /// <summary>
        /// Checks whether the character is Latin
        /// </summary>
        /// <param name="character"></param>
        /// <returns>True if Latin, otherwise false</returns>
        private static bool IsLatin(char character)
        {
            return character >= 65 && character <= 90 || character >= 97 && character <= 122;
        }
    }
}