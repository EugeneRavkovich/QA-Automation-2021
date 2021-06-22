namespace Triangles
{
    class EquilateralTriangleHandler: Handler
    {
        public override void Handle(double[,] points, double[] edges)
        {
            if (Helper.IsEquilateral(edges))
            {
                base.CreatedTriangle = new EquilateralTriangleCreator().Create(points);
            }
            else if (Next != null)
            {
                Next.Handle(points, edges);
            }
        }
    }
}
