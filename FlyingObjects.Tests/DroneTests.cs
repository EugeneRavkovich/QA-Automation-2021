using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfacesAndAbstractClasses;
using System;

namespace FlyingObjects.Tests
{
    [TestClass]
    public class DroneTests
    {
        private static Drone _drone;


        [TestInitialize]
        public void TestInitialize() 
        {
            _drone = new Drone(new Coordinate(0, 0, 0), maxDistance: 36, speed: 36);
        }


        [TestMethod]
        public void IsCanFlyToMaxDistance()
        {
            Assert.AreEqual(true, _drone.IsCanFlyTo(new Coordinate(18 * Math.Sqrt(2), 18 * Math.Sqrt(2), 0)));
        }


        [TestMethod]
        public void IsCanFlyToPointOutOfAcceptableRange()
        {
            Assert.AreEqual(false, _drone.IsCanFlyTo(new Coordinate(36, 36, 0)));
        }


        [TestMethod]
        public void IsCanFlyToCurrentPoint()
        {
            Assert.AreEqual(true, _drone.IsCanFlyTo(new Coordinate(0, 0, 0)));
        }


        [TestMethod]
        public void IsCanFlyToNextPointWithZeroSpeed()
        {
            _drone.Speed = 0;
            Assert.AreEqual(false, _drone.IsCanFlyTo(new Coordinate(3, 4, 5)));
        }


        [TestMethod]
        public void FlyToMaxDistance()
        {
            _drone.FlyTo(new Coordinate(0, 36, 0));
            Assert.AreEqual(new Coordinate(0, 36, 0), _drone.CurrentPosition);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FlyToPointOutOfAcceptableRange()
        {
            _drone.FlyTo(new Coordinate(36, 36, 36));
        }


        [TestMethod]
        public void FlyToCurrentPoint()
        {
            _drone.FlyTo(new Coordinate(0, 0, 0));
            Assert.AreEqual(new Coordinate(0, 0, 0), _drone.CurrentPosition);
        }


        [TestMethod]
        public void GetFlyTimeToMaxDistance()
        {
            Assert.AreEqual(TimeSpan.Parse("01:05:00"), _drone.GetFlyTime(new Coordinate(18 * Math.Sqrt(2), 18 * Math.Sqrt(2), 0)));
        }


        [TestMethod]
        public void GetFlyTimeToCurrentPoint()
        {
            Assert.AreEqual(TimeSpan.FromHours(0), _drone.GetFlyTime(new Coordinate(0, 0, 0)));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFlyTimeToPointOutOfAcceptableRange()
        {
            _drone.GetFlyTime(new Coordinate(36, 36, 36));
        }
    }
}
