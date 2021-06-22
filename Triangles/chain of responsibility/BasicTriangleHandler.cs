namespace Triangles
{
    class BasicTriangleHandler: Handler
    {
        public override void Handle(double[,] points, double[] edges)
        {
            base.CreatedTriangle = new BasicTriangleCreator().Create(points);
        }
    }
}
