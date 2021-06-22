namespace Triangles
{
    class RightTriangleCreator: Creator
    {
        public override BaseTriangle Create(double[,] points)
        {
            return new RightTriangle(points);
        }
    }
}
