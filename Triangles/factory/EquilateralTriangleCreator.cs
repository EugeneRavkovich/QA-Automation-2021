namespace Triangles
{
    class EquilateralTriangleCreator: Creator
    {
        public override BaseTriangle Create(double[,] points)
        {
            return new EquilateralTriangle(points);
        }
    }
}
