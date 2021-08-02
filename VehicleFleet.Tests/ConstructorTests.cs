using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VehicleFleet.Tests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InitializationException))]
        public void TryToCreateCarWithoutEngine()
        {
            Vehicle car = new PassengerCar(
                null,
                new Chassis(4, "RT321Q", 2),
                new Transmission(TransmissionType.Automatic, 10, "Jatco"), 4);
        }


        [TestMethod]
        [ExpectedException(typeof(InitializationException))]
        public void TryToCreateCarWithoutChassis()
        {
            Vehicle car = new PassengerCar(
                new Engine(230, 3.2, EngineType.Petrol, "E2415O"),
                null,
                new Transmission(TransmissionType.Automatic, 10, "Jatco"), 4);
        }


        [TestMethod]
        [ExpectedException(typeof(InitializationException))]
        public void TryToCreateCarWithoutTransmission()
        {
            Vehicle car = new PassengerCar(
                new Engine(230, 3.2, EngineType.Petrol, "E2415O"),
                new Chassis(4, "RT321Q", 2),
                null, 4);
        }
    }
}
