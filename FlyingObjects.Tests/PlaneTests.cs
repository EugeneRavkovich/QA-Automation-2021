using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfacesAndAbstractClasses;
using System;


namespace FlyingObjects.Tests
{
    [TestClass]
    public class PlaneTests
    {
        private static Plane _plane;


        [TestInitialize]
        public void TestInitialize() 
        {
            _plane = new Plane(new Coordinate(0, 0, 0), tankCapacity: 50000,
                               fuelConsumption: 5000, maxSpeed: 1000);

            // maxDistance = 50000 litres / 5000 litres per thousand kilometers * 1000 = 10000 km
        }


        [TestMethod]
        public void IsCanFlyToMaxDistance()
        {
            Assert.AreEqual(true, _plane.IsCanFlyTo(new Coordinate(6000, 8000, 0)));
        }


        [TestMethod]
        public void IsCanFlyToPointOutOfAcceptableRange()
        {
            Assert.AreEqual(false, _plane.IsCanFlyTo(new Coordinate(10000, 10000, 10000)));
        }


        [TestMethod]
        public void IsCanFlyToCurrentPoint()
        {
            Assert.AreEqual(true, _plane.IsCanFlyTo(new Coordinate(0, 0, 0)));
        }


        [TestMethod]
        public void FlyToMaxDistance()
        {
            _plane.FlyTo(new Coordinate(6000, 8000, 0));
            Assert.AreEqual(new Coordinate(6000, 8000, 0), _plane.CurrentPosition);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FlyToPointOutOfAcceptableRange()
        {
            _plane.FlyTo(new Coordinate(10000, 10000, 10000));
        }


        [TestMethod]
        public void FlyToCurrentPoint()
        {
            _plane.FlyTo(new Coordinate(0, 0, 0));
            Assert.AreEqual(new Coordinate(0, 0, 0), _plane.CurrentPosition);
        }


        [TestMethod]
        public void GetFlyTimeToMaxDistance()
        {
            Assert.AreEqual(TimeSpan.Parse("10:49:46.6962977"), _plane.GetFlyTime(new Coordinate(6000, 8000, 0)));
        }


        [TestMethod]
        public void GetFlyTimeToCurrentPoint()
        {
            Assert.AreEqual(TimeSpan.FromHours(0), _plane.GetFlyTime(new Coordinate(0, 0, 0)));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFlyTimeToPointOutOfAcceptableRange()
        {
            _plane.GetFlyTime(new Coordinate(10000, 10000, 10000));
        }
    }
}
