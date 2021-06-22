using System;

namespace DegreeOfTwo
{
    class EntryPoint
    {
        static void Main()
        {
            int[] numbers = new int[10];
            numbers[0] = 1;

            Console.Write(numbers[0] + "\t");
            for (int i = 1; i < numbers.Length; i++) 
            {
                numbers[i] = numbers[i-1] * 2;
                Console.Write(numbers[i] + "\t");
            }

            Console.WriteLine();
        }
    }
}
