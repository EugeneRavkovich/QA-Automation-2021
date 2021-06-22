using System;
using System.Linq;

namespace SwapMinMaxElements
{
    class EntryPoint
    {
        static void Main()
        {
            int[] numbers = new int[] { 3, 4, 1, 10, 15, 6, 9, 20, 13, 7};
            PrintMassive(numbers);
            int minIndex = Array.IndexOf(numbers, numbers.Min());
            int maxIndex = Array.IndexOf(numbers, numbers.Max());
            int tmp = numbers[maxIndex];
            numbers[maxIndex] = numbers[minIndex];
            numbers[minIndex] = tmp;
            PrintMassive(numbers);
        }

        static void PrintMassive(int[] arr) 
        {
            for (int i = 0; i < arr.Length; i++) 
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
