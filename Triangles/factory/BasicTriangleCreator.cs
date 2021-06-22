namespace Triangles
{
    class BasicTriangleCreator: Creator
    {
        public override BaseTriangle Create(double[,] points)
        {
            return new BasicTriangle(points);
        }
    }
}
