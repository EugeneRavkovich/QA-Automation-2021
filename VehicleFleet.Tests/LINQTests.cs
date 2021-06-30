using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace VehicleFleet.Tests
{
    [TestClass]
    public class LINQTests
    {
        private static VehicleFleet _park;
        private static VehicleFleet _emptyPark;


        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _emptyPark = new VehicleFleet();

            _park = new VehicleFleet(new List<Vehicle>
            {
                new Bus(
                    new Engine(160, 5.0, EngineType.Diesel, "I3333U"),
                    new Chassis(8, "WQ222Q", 22),
                    new Transmission(TransmissionType.Automatic, 7, "Jatko"), "144c"),

                new PassengerCar(
                    new Engine(230, 3.2, EngineType.Petrol, "E2415O"),
                    new Chassis(4, "RT321Q", 2),
                    new Transmission(TransmissionType.Automatic, 10, "Jatco"), 4),

                new Scooter(
                    new Engine(60, 1.2, EngineType.Gas, "KW23121P"),
                    new Chassis(4, "123121", 22),
                    new Transmission(TransmissionType.Automatic, 4, "Jatko"), 120),

                new Truck(
                    new Engine(350, 5.0, EngineType.Petrol, "T2103I"),
                    new Chassis(6, "QI857N", 15),
                    new Transmission(TransmissionType.Mechanic, 7, "Jatco"), 12)
            });
        }


        [TestMethod]
        public void GetVehiclesWithEngineVolumeGreaterThanValue()
        {
            Assert.AreEqual(3, _park.GetVehiclesWithEngineVolumeGreaterThan(1.5).Count);
        }


        [TestMethod]
        public void GetVehiclesWithEngineVolumeGreaterThanValue_EmptyFleet()
        {
            Assert.AreEqual(0, _emptyPark.GetVehiclesWithEngineVolumeGreaterThan(1.5).Count);
        }


        [TestMethod]
        public void GetEnginesOfBussesAndTrucks()
        {
            Assert.AreEqual(2, _park.GetEnginesOfBussesAndTrucks().Count);
        }


        [TestMethod]
        public void GetEnginesOfBussesAndTrucks_EmptyFleet()
        {
            Assert.AreEqual(0, _emptyPark.GetEnginesOfBussesAndTrucks().Count);
        }


        [TestMethod]
        public void GroupByTransmission() 
        {
            var order = (from vehicle in _park.GroupByTransmission()
                         select vehicle.Transmission.Type).ToList();

            var expectedOrder = new List<TransmissionType>
            {
                TransmissionType.Automatic,
                TransmissionType.Automatic,
                TransmissionType.Automatic,
                TransmissionType.Mechanic
            };
            Assert.IsTrue(expectedOrder.SequenceEqual(order));
        }
    }
}
