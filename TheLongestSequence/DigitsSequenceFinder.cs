namespace TheLongestSequence
{
    /// <summary>
    /// Contains method for finding the longest sequence of identical digits
    /// </summary>
    public static class DigitsSequenceFinder
    {
        /// <summary>
        /// Selects the longest subsequence of identical digits
        /// </summary>
        /// <param name="inputSequence">Input sequence in which the search is performed</param>
        /// <returns>Length of the longest subsequence</returns>
        public static int GetTheLongestIdenticalDigitsSequenceLength(this string inputSequence)
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
                if (char.IsDigit(character) && character == buffer)
                {
                    currentSubsequenceLength++;
                }
                else if (char.IsDigit(character))
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
    }
}