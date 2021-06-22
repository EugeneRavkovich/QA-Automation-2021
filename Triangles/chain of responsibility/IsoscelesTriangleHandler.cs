namespace Triangles
{
    class IsoscelesTriangleHandler: Handler
    {
        public override void Handle(double[,] points, double[] edges)
        {
            if (Helper.IsIsosceles(edges))
            {
                base.CreatedTriangle = new IsoscelesTriangleCreator().Create(points);
            }
            else if (Next != null)
            {
                Next.Handle(points, edges);
            }
        }
    }
}
