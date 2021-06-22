using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Triangles.Tests
{   
    [TestClass]
    public class TriangleBuilderTests
    {
        readonly double[,] rightTriangle = { { 0, 0 }, { 0, 4 }, { 3, 0 } };
        readonly double[,] isoscelesTriangle = { { 1, 1 }, { 3, 5 }, { 5, 1 } };
        readonly double[,] equilateralTriangle = { { 1, 1 }, { 3, 2 * Math.Sqrt(3) + 1 }, { 5, 1 } };


        [TestMethod]
        public void TriangleBuilderReturnsRightTrianglePositive() 
        {
            BaseTriangle triangle = new TriangleBuilder(rightTriangle).Create();
            Assert.AreEqual(typeof(RightTriangle), triangle.GetType());
        }


        [TestMethod]
        public void TriangleBuilderReturnsIsoscelesTrianglePositive() 
        {
            BaseTriangle triangle = new TriangleBuilder(isoscelesTriangle).Create();
            Assert.AreEqual(typeof(IsoscelesTriangle), triangle.GetType());
        }


        [TestMethod]
        public void TriangleBuilderReturnsEquilateralTrianglePositive()
        {
            BaseTriangle triangle = new TriangleBuilder(equilateralTriangle).Create();
            Assert.AreEqual(typeof(EquilateralTriangle), triangle.GetType());
        }
    }
}
