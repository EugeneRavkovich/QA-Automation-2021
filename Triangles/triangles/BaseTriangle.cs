using System;

namespace Triangles
{
    /// <summary>
    /// The basic implementation of a triangle for inheritance.
    /// Base constructure for derived classes.
    /// </summary>
    public abstract class BaseTriangle
    {
        public double[,] points;
        public string color { get; protected set; }


        public BaseTriangle()
        {
            points = new double[3, 2];
            this.color = string.Empty;
        }


        public BaseTriangle(double[,] points, string color)
        {
            
            this.points = points;
            this.color = color;  
        }

        
        /// <summary>
        /// Calculating the area of a triangle via Heron's formula.
        /// </summary>
        /// <returns>Triangle's area</returns>
        public double CalculateArea()
        {
            double[] edges = Helper.CalculateEdges(points);
            double halfPerimeter = 0;
            foreach (double element in edges)
            {
                halfPerimeter += element / 2;
            }
            double area = halfPerimeter;
            foreach (double element in edges)
            {
                area *= halfPerimeter - element;
            }
            return Math.Sqrt(area);
        } 
    }
}
