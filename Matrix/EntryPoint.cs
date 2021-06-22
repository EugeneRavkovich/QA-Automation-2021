using System;

namespace Matrix
{
    public class EntryPoint
    {
        static void Main(string[] args)
        {

            double[] numbers1 = new double[9]
            {   1, 2, 3,
                4, 5, 6,
                7, 8, 9
            };

            double[] numbers2 = new double[3] { 1, 2, 3 };
            try
            {

                SquareMatrix squareMatrix = new SquareMatrix(numbers1);
                squareMatrix[1, 1] = 0;
                Console.WriteLine("SquareMatrix");
                Console.Write(squareMatrix.ToString());

                Console.WriteLine("DiagonalMatrix");
                DiagonalMatrix diagonalMatrix = new DiagonalMatrix(numbers2);
                Console.Write(diagonalMatrix.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
