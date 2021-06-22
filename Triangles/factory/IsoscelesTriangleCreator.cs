namespace Triangles
{
    class IsoscelesTriangleCreator: Creator
    {
        public override BaseTriangle Create(double[,] points)
        {
            return new IsoscelesTriangle(points);
        }
    }
}
