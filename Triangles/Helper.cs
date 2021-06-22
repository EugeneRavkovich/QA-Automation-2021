using System;

namespace Triangles
{
    public class Helper
    {
        public static double[] CalculateEdges(double[,] points)
        {
            if (points.GetLength(0) < 2)
            {
                throw new Exception("Not enought points to calculate edges");
            }
            double[] pairwiseDistances = new double[2];
            double[] edges = new double[points.GetLength(0)];
            int edgeCounter = 0;

            double tmp;
            for (int currentPoint = 0; currentPoint < points.GetLength(0) - 1; currentPoint++)
            {
                for (int nextPoint = currentPoint + 1; nextPoint < points.GetLength(0); nextPoint++)
                {
                    double squaredDistance = 0;
                    for (int pointCoordinate = 0; pointCoordinate < points.GetLength(1); pointCoordinate++)
                    {
                        tmp = Math.Abs(points[currentPoint, pointCoordinate] -
                                       points[nextPoint, pointCoordinate]);
                        pairwiseDistances[pointCoordinate] = tmp;
                        squaredDistance += tmp * tmp;
                    }
                    edges[edgeCounter] = Math.Sqrt(squaredDistance);
                    edgeCounter++;
                }
            }
            return edges;
        }


        public static bool IsEquilateral(double[] edges)
        {
            for (int index = 0; index < edges.Length - 1; index++)
            {
                if (Math.Abs(edges[index] - edges[index + 1]) > 1e-10)
                {
                    return false;
                }
            }
            return true;
        }


        public static bool IsIsosceles(double[] edges)
        {
            int counter = 0;
            for (int currentEdge = 0; currentEdge < edges.Length - 1; currentEdge++)
            {
                for (int nextEdge = currentEdge + 1; nextEdge < edges.Length; nextEdge++)
                {
                    if (Math.Abs(edges[currentEdge] - edges[nextEdge]) < double.Epsilon)
                    {
                        counter++;
                    }
                }
            }
            return counter == 1;
        }


        public static bool IsRight(double[] edges)
        {
            Array.Sort(edges);
            double edge1 = edges[0];
            double edge2 = edges[1];
            double longestEdge = edges[2];
            return Math.Abs(edge1 * edge1 + edge2 * edge2 - longestEdge * longestEdge) <= 1e-10;
        }


        public static bool IsAbleToCreate(double[] edges)
        {
            Array.Sort(edges);
            double edge1 = edges[0];
            double edge2 = edges[1];
            double longestEdge = edges[2];
            return Math.Abs(edge1 + edge2 - longestEdge) > double.Epsilon;
        }
    }
}
