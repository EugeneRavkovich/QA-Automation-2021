using System;

namespace TheLongestSequence
{
    class Program
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
                Console.WriteLine(maxSubsequenceLength);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
