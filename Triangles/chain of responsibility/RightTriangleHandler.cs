namespace Triangles
{
    class RightTriangleHandler: Handler
    {
        public override void Handle(double[,] points, double[] edges)
        {
            if (Helper.IsRight(edges))
            {
                base.CreatedTriangle = new RightTriangleCreator().Create(points);
            }
            else if (Next != null)
            {
                Next.Handle(points, edges);
            }
        }
    }
}
