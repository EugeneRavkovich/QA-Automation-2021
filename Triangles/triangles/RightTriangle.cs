namespace Triangles
{
    /// <summary>
    /// Provides an instance of a right triangle -
    /// triangle with 90 degrees angle
    /// </summary>
    public class RightTriangle: BaseTriangle
    {
        readonly static string figureColor = "green";


        public RightTriangle() 
        {
            base.color = figureColor;
        }


        public RightTriangle(double[,] points) : base(points, figureColor) { } 
    }
}
