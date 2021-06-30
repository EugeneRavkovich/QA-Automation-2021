using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfacesAndAbstractClasses;
using System;

namespace FlyingObjects.Tests
{
    [TestClass]
    public class CoordinateTests
    {
        private static Coordinate _point;


        [TestInitialize]
        public void TestInitialize() 
        {
            _point = new Coordinate(0, 0, 0);
        }


        [TestMethod]
        public void ClaculateDistanceToPointWithPositiveCoordinates() 
        {
            Coordinate nextPoint = new Coordinate(12 * Math.Sqrt(3), 12 * Math.Sqrt(3), 12 * Math.Sqrt(3));
            Assert.AreEqual(36, _point.CalculateDistance(nextPoint), double.Epsilon);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateDistamceToPointWithNegativeCoordinates() 
        {
            Coordinate nextPoint = new Coordinate(-12 * Math.Sqrt(3), -12 * Math.Sqrt(3), -12 * Math.Sqrt(3));
            var distance = _point.CalculateDistance(nextPoint);
        }


        [TestMethod]
        public void CalculateDistanceToCurrentPoint() 
        {
            Assert.AreEqual(0, _point.CalculateDistance(_point), double.Epsilon);
        }
    }
}
