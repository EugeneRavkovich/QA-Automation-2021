using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfacesAndAbstractClasses;
using System;

namespace FlyingObjects.Tests
{
    [TestClass]
    public class BirdTests
    {
        private static Bird _bird;


        [TestInitialize]
        public void TestInitialize()
        {
            _bird = new Bird(new Coordinate(0, 0, 0), maxDistance: 10);
        }


        [TestMethod]
        public void IsCanFlyToMaxDistance()
        {
            Assert.AreEqual(true, _bird.IsCanFlyTo(new Coordinate(6, 8, 0)));
        }


        [TestMethod]
        public void IsCanFlyToPointOutOfAcceptableRange()
        {
            Assert.AreEqual(false, _bird.IsCanFlyTo(new Coordinate(10, 10, 10)));
        }


        [TestMethod]
        public void IsCanFlyToCurrentPoint() 
        {
            Assert.AreEqual(true, _bird.IsCanFlyTo(new Coordinate(0, 0, 0)));
        }


        [TestMethod]
        public void IsCanFlyToNextPointWithZeroSpeed() 
        {
            _bird.Speed = 0;
            Assert.AreEqual(false, _bird.IsCanFlyTo(new Coordinate(3, 4, 5)));
        }


        [TestMethod]
        public void FlyToMaxDistance() 
        {
            _bird.FlyTo(new Coordinate(6, 8, 0));
            Assert.AreEqual(new Coordinate(6, 8, 0), _bird.CurrentPosition);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FlyToPointOutOfAcceptableRange() 
        {
            _bird.FlyTo(new Coordinate(10, 10, 10)); 
        }


        [TestMethod]
        public void FlyToCurrentPoint() 
        {
            _bird.FlyTo(new Coordinate(0, 0, 0));
            Assert.AreEqual(new Coordinate(0, 0, 0), _bird.CurrentPosition);
        }


        [TestMethod]
        public void GetFlyTimeToMaxDistance()
        {
            _bird.Speed = 10;
            Assert.AreEqual(TimeSpan.FromHours(1), _bird.GetFlyTime(new Coordinate(6, 8, 0)));
        }


        [TestMethod]
        public void GetFlyTimeToCurrentPoint() 
        {
            Assert.AreEqual(TimeSpan.FromHours(0), _bird.GetFlyTime(new Coordinate(0, 0, 0)));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFlyTimeToPointOutOfAcceptableRange() 
        {
            _bird.GetFlyTime(new Coordinate(10, 10, 10));
        }
    }
}
