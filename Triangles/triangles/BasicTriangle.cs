namespace Triangles
{
    /// <summary>
    /// Povides an instance of a simple triangle -
    /// triangle with three different sides
    /// </summary>
    public class BasicTriangle: BaseTriangle
    {
        readonly static string figureColor = "white";


        public BasicTriangle() 
        {
            base.color = figureColor;
        }


        public BasicTriangle(double[,] points) : base(points, figureColor) { }
    }
}
