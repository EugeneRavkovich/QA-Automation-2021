using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Matrix.Tests
{
    [TestClass]
    public class MatrixTests
    {
        readonly SquareMatrix squareMatrix = new SquareMatrix(
            new double[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        readonly DiagonalMatrix diagonalMatrix = new DiagonalMatrix(
            new double[3] { 1, 2, 3 });


        [TestMethod]
        [DataRow(0, 0, 1)]
        [DataRow(0, 1, 2)]
        [DataRow(2, 1, 8)]
        public void GetSquareMatrixElementPositive(int i, int j, double value) 
        {
            Assert.AreEqual(value, squareMatrix[i, j]);
        }


        [TestMethod]
        [DataRow(0, 0, 1)]
        [DataRow(0, 1, 0)]
        [DataRow(2, 1, 0)]
        public void GetDiagonalMatrixElementPositive(int i, int j, double value)
        {
            Assert.AreEqual(value, diagonalMatrix[i, j]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(-1, -1)]
        [DataRow(1, -1)]
        [DataRow(-1, 10)]
        [DataRow(1, 10)]
        [DataRow(10, 10)]
        public void GetMatrixElementByWrongIndicesNegative(int i, int j)
        {
            var element = squareMatrix[i, j];
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(-1, -1)]
        [DataRow(1, -1)]
        [DataRow(-1, 10)]
        [DataRow(1, 10)]
        [DataRow(10, 10)]
        public void SetSquareMatrixElementNegative(int i, int j, double value = 3.3)
        {
            squareMatrix[i, j] = value;
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(-1, -1)]
        [DataRow(1, -1)]
        [DataRow(-1, 10)]
        [DataRow(1, 10)]
        [DataRow(10, 10)]
        [DataRow(0, 1)]
        [DataRow(2, 1)]
        public void SetDiagonalMatrixElementNegative(int i, int j, double value = 3.3) 
        {
            diagonalMatrix[i, j] = value;
        }
    }
}
