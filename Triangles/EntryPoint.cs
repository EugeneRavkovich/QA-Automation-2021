using System;

namespace Triangles
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                double[,] points = { { 0, 0 }, { 0, 4 }, { 3, 0 } };
                BaseTriangle triangle1 = new TriangleBuilder(points).Create();
                Console.WriteLine(triangle1.CalculateArea());
                Console.WriteLine(triangle1.GetType());
                Console.WriteLine(triangle1.color);
                Console.ReadKey();

                bool isNotOver = true;
                while (isNotOver)
                {
                    BaseTriangle triangle2 = new TriangleBuilder().Create();
                    Console.WriteLine(triangle2.CalculateArea());
                    Console.WriteLine(triangle2.GetType());
                    Console.WriteLine(triangle2.color);
                    isNotOver = (Console.ReadKey().Key != ConsoleKey.Escape);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
