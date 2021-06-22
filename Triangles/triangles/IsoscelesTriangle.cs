namespace Triangles
{
    /// <summary>
    /// Provides an instance of a isosceles triangle - 
    /// triangle with a two equal sides
    /// </summary>
    public class IsoscelesTriangle: BaseTriangle
    {
        readonly static string figureColor = "blue";


        public IsoscelesTriangle()
        {
            base.color = figureColor;
        }


        public IsoscelesTriangle(double[,] points) : base(points, figureColor) { }
    }
}
