using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Triangles.Tests
{
    [TestClass]
    public class HelperTests
    {
        readonly double[,] rightTriangleWithPositiveCoordinates = { { 1, 1 }, { 1, 5 }, { 4, 1 } };
        readonly double[,] rightTriangleWithNegativeCoordinates = { { -1, -1 }, { -1, -5 }, { -4, -1 } };
        readonly double[,] rightTriangleWithMixedCoordinates = { { -1, 1 }, { -1, 5 }, { -4, 1 } };

        readonly double[,] isoscelesTriangleWithPositiveCoordinates = { { 1, 1 }, { 3, 5 }, { 5, 1 } };
        readonly double[,] isoscelesTriangleWithNegativeCoordinates = { { -1, -1 }, { -3, -5 }, { -5, -1 } };
        readonly double[,] isoscelesTriangleWithMixedCoordinates = { { -1, 1 }, { -3, 5 }, { -5, 1 } };

        readonly double[,] equilateralTriangleWithPositiveCoordinates = { { 1, 1 }, { 3, 2 * Math.Sqrt(3) + 1 }, { 5, 1 } };
        readonly double[,] equilateralTriangleWithNegativeCoordinates = { { -1, -1 }, { -3, -2 * Math.Sqrt(3) - 1 }, { -5, -1 } };
        readonly double[,] equilateralTriangleWithMixedCoordinates = { { -1, 1 }, { -3, 2 * Math.Sqrt(3) + 1 }, { -5, 1 } };

        readonly double[,] nonexistentTriangle = { { 1, 1 }, { 5, 5 }, { 10, 10 } };


        [TestMethod]
        public void CalculateEdgesPositive()
        {
            double[] expectedEdges = { 3, 4, 5 };
            double[] actualEdges = Helper.CalculateEdges(rightTriangleWithMixedCoordinates);
            Array.Sort(actualEdges);
            int counter = 0;
            for (int i = 0; i < expectedEdges.Length; i++)
            {
                if (Math.Abs(expectedEdges[i] - actualEdges[i]) <= double.Epsilon)
                {
                    counter++;
                }
            }

            Assert.AreEqual(3, counter);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateEdgesNegative()
        {
            double[,] points = { { 1, 2 } };
            double[] actualEdges = Helper.CalculateEdges(points);
        }


        [TestMethod]
        public void IsAbleToCreatePositive() 
        {
            var edges = Helper.CalculateEdges(rightTriangleWithPositiveCoordinates);
            Assert.AreEqual(true, Helper.IsAbleToCreate(edges));
        }


        [TestMethod]
        public void IsAbleToCreateNegative() 
        {
            var edges = Helper.CalculateEdges(nonexistentTriangle);
            Assert.AreEqual(false, Helper.IsAbleToCreate(edges));
        }


        [TestMethod]
        public void IsEquilateralTriangleWithPositiveCoordinatesPositive()
        {
            var edges = Helper.CalculateEdges(equilateralTriangleWithPositiveCoordinates);
            Assert.AreEqual(true, Helper.IsEquilateral(edges));
        }

        [TestMethod]
        public void IsEquilateralTriangleWithNegativeCoordinatesPositive()
        {
            var edges = Helper.CalculateEdges(equilateralTriangleWithNegativeCoordinates);
            Assert.AreEqual(true, Helper.IsEquilateral(edges));
        }


        [TestMethod]
        public void IsEquilateralTriangleWithMixedCoordinatesPositive()
        {
            var edges = Helper.CalculateEdges(equilateralTriangleWithMixedCoordinates);
            Assert.AreEqual(true, Helper.IsEquilateral(edges));
        }


        [TestMethod]
        public void IsEquilateralTriangleWithWrongCoordinatesNegative()
        {
            var edges = Helper.CalculateEdges(rightTriangleWithPositiveCoordinates);
            Assert.AreEqual(false, Helper.IsEquilateral(edges));
        }


        [TestMethod]
        public void IsRightTriangleWithPositiveCoordinatesPositive()
        {
            var edges = Helper.CalculateEdges(rightTriangleWithPositiveCoordinates);
            Assert.AreEqual(true, Helper.IsRight(edges));
        }


        [TestMethod]
        public void IsRightTriangleWithNegativeCoordinatesPositive()
        {
            var edges = Helper.CalculateEdges(rightTriangleWithNegativeCoordinates);
            Assert.AreEqual(true, Helper.IsRight(edges));
        }


        [TestMethod]
        public void IsRightTriangleWithMidexCoordinatesPositive()
        {
            var edges = Helper.CalculateEdges(rightTriangleWithMixedCoordinates);
            Assert.AreEqual(true, Helper.IsRight(edges));
        }


        [TestMethod]
        public void IsRightTriangleWithWrongCoordinatesNegative()
        {
            var edges = Helper.CalculateEdges(equilateralTriangleWithPositiveCoordinates);
            Assert.AreEqual(false, Helper.IsRight(edges));
        }


        [TestMethod]
        public void IsIsoscelesTriangleWithPositiveCoordinatesPositive()
        {
            var edges = Helper.CalculateEdges(isoscelesTriangleWithPositiveCoordinates);
            Assert.AreEqual(true, Helper.IsIsosceles(edges));
        }


        [TestMethod]
        public void IsIsoscelesTriangleWithNegativeCoordinatesPositive()
        {
            var edges = Helper.CalculateEdges(isoscelesTriangleWithNegativeCoordinates);
            Assert.AreEqual(true, Helper.IsIsosceles(edges));
        }


        [TestMethod]
        public void IsIsoscelesTriangleWithMixedCoordinatesPositive() 
        {
            var edges = Helper.CalculateEdges(isoscelesTriangleWithMixedCoordinates);
            Assert.AreEqual(true, Helper.IsIsosceles(edges));
        }


        [TestMethod]
        public void IsIsoscelesTriangleWithWrongCoordinatesNegative() 
        {
            var edges = Helper.CalculateEdges(rightTriangleWithMixedCoordinates);
            Assert.AreEqual(false, Helper.IsIsosceles(edges));
        }
    }
}
