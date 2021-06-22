using System;

namespace ArrayMean
{
    class EntryPoint
    {
        static void Main()
        {
            int[] numbers = new int[10];
            Random randomNumber = new Random();
            int sum = 0;
            for(int i=0; i<numbers.Length; i++) 
            {
                numbers[i] = randomNumber.Next(10);
                sum += numbers[i];
                Console.Write(numbers[i] + "\t");
            }
            Console.WriteLine("\n" + (float)sum/numbers.Length);
        }
    }
}
