namespace Triangles
{
    /// <summary>
    /// Provides an instance of a equilateral triangle -
    /// triangle with three equal sides
    /// </summary>
    public class EquilateralTriangle: BaseTriangle
    {
        readonly static string figureColor = "red";


        public EquilateralTriangle() 
        {
            base.color = figureColor;
        }


        public EquilateralTriangle(double[,] points) : base(points, figureColor) { }
    }
}