namespace Triangles
{
    abstract class Handler
    {
        public BaseTriangle CreatedTriangle { get; set; }
        public Handler Next { get; set; }
        public abstract void Handle(double[,] points, double[] edges);
    }
}