using System;

namespace TheLongestSequence
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            string inputSequence;
            if (args.Length == 0)
            {
                inputSequence = string.Empty;
            }
            else
            {
                inputSequence = args[0];
            }

            try
            {
                var maxSubsequenceLength = inputSequence.GetTheLongestUniqueSubsequenceLength();
                var maxLatinSubsequenceLength = inputSequence.GetTheLongestIdenticalLatinLettersSequenceLength();
                var maxDigitsSubsequenceLength = inputSequence.GetTheLongestIdenticalDigitsSequenceLength();
                Console.WriteLine(maxSubsequenceLength);
                Console.WriteLine(maxLatinSubsequenceLength);
                Console.WriteLine(maxDigitsSubsequenceLength);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
