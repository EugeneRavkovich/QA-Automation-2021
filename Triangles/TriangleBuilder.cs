using System;

namespace Triangles
{
    /// <summary>
    /// Creates a necessary triangle object based on input coordinates
    /// </summary>
    public class TriangleBuilder
    {
        public double[,] points;
        public double[] edges;

        public TriangleBuilder() 
        {
            points = new double[3, 2];
            EnterPoints();
            edges = Helper.CalculateEdges(points);
        }

        public TriangleBuilder(double[,] points) 
        {
            this.points = points;
            this.edges = Helper.CalculateEdges(points);
        }

        /// <summary>
        /// Method for filling the coordinates if such option is chosen
        /// </summary>
        public void EnterPoints()
        {
            Console.WriteLine("Enter points coordinates");
            for (int i = 0; i < points.GetLength(0); i++)
            {
                Console.WriteLine($"Point{i}:");
                for (int j = 0; j < points.GetLength(1); j++)
                {
                    Console.WriteLine((j == 0) ? "x: " : "y: ");
                    points[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }

        /// <summary>
        /// Method that creates a necessary triangle based on input coordinates
        /// </summary>
        /// <returns>Corresponding triangle object</returns>
        public BaseTriangle Create() 
        {
            if (Helper.IsAbleToCreate(edges))
            {
                Handler handler1 = new EquilateralTriangleHandler();
                Handler handler2 = new RightTriangleHandler();
                Handler handler3 = new IsoscelesTriangleHandler();
                Handler handler4 = new BasicTriangleHandler();
                handler1.Next = handler2;
                handler2.Next = handler3;
                handler3.Next = handler4;
                handler1.Handle(points, edges);
                Handler[] handlers = { handler1, handler2, handler3, handler4 };
                foreach (Handler handler in handlers)
                {
                    if (handler.CreatedTriangle != null)
                    {
                        return handler.CreatedTriangle;
                    }
                }
                return null;
            }
            else 
            {
                throw new Exception("Unable to create");
            }
        }
    }
}
