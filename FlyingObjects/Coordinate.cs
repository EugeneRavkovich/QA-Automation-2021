using System;

namespace InterfacesAndAbstractClasses
{
    public struct Coordinate
    {
        private double _x;
        private double _y;
        private double _z;


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Coordinate(double x, double y, double z)
        {
            if ( x < 0 || y < 0 || z < 0) 
            {
                throw new ArgumentException($"\nPoint ({x}, {y}, {z}): Only positive coordinates are allowed");
            }
            else 
            {
                this._x = x;
                this._y = y;
                this._z = z;
            }  
        }


        /// <summary>
        /// Calculates the distance between current and next points
        /// </summary>
        /// <param name="nextPosition">Destination point</param>
        /// <returns>Distance between points, measured in km</returns>
        public double CalculateDistance(Coordinate nextPosition) 
        {
            return Math.Sqrt(Math.Pow((nextPosition._x - _x), 2) +
                   Math.Pow((nextPosition._y - _y), 2) +
                   Math.Pow((nextPosition._z - _z), 2)); 
        }
    }
}
 