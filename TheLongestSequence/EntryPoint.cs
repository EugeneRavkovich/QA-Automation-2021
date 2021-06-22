using System;

namespace TheLongestSequence
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            string inputSequece;
            if (args.Length == 0)
            {
                inputSequece = string.Empty;
            }
            else
            {
                inputSequece = args[0];
            }

            try
            {
                Console.WriteLine("Input sequence: " + inputSequece);
                Console.WriteLine("Length: " + inputSequece.Length);

                var maxSubsequence = inputSequece.GetTheLongestUniqueSubsequence();

                Console.WriteLine("The longest subsequence: " + maxSubsequence);
                Console.WriteLine("Length: " + maxSubsequence.Length);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
