using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace VehicleFleet.Tests
{
    [TestClass]
    public class VehicleFleetTests
    {
        private static VehicleFleet _park;
        private static VehicleFleet _emptyPark;
        private static Vehicle _carWithWrongId;
        private static Vehicle _electricalCar;
        private static Vehicle _carForAdd;

        [TestInitialize]
        public void TestInitialize()
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

            _carWithWrongId = new PassengerCar(
                    new Engine(230, 3.2, EngineType.Petrol, "E2415O"),
                    new Chassis(4, "RT321Q", 2),
                    new Transmission(TransmissionType.Automatic, 10, "Jatco"), 4);
            _carWithWrongId.Id = _park.Vehicles[0].Id;

            _electricalCar = new PassengerCar(
                    new Engine(230, 3.2, EngineType.Electric, "E2415O"),
                    new Chassis(4, "RT321Q", 2),
                    new Transmission(TransmissionType.Automatic, 10, "Jatco"), 4);

            _carForAdd = new PassengerCar(
                    new Engine(200, 3.2, EngineType.Petrol, "E2415O"),
                    new Chassis(4, "RT321Q", 2),
                    new Transmission(TransmissionType.Automatic, 10, "Jatco"), 4);
        }


        [TestMethod]
        [ExpectedException(typeof(AddException))]
        public void AddVehicleWithWrongId()
        {
            _park.Add(_carWithWrongId);
        }


        [TestMethod]
        [ExpectedException(typeof(AddException))]
        public void AddVehicleWithElectricalEngine()
        {
            _park.Add(_electricalCar);
        }


        [TestMethod]
        public void AddCorrectVehicle()
        {
            _park.Add(_carForAdd);
            Assert.AreEqual(5, _park.Vehicles.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(GetAutoByParameterException))]
        public void GetAutoByParameterWithWrongParameter()
        {
            _park.GetAutoByParameter("qwe", "4");
        }


        [TestMethod]
        public void GetAutoByParameterWithCorrectParameterAndWrongValue()
        {
            Assert.AreEqual(0, _park.GetAutoByParameter("PassengersQuantity", "444").Count);
        }


        [TestMethod]
        public void GetAutoByParameterWithCorrectInputs()
        {
            Assert.AreEqual(1, _park.GetAutoByParameter("LoadCapacity", "12").Count);
        }


        [TestMethod]
        [ExpectedException(typeof(UpdateAutoException))]
        public void UpdateAutoWithWrongId()
        {
            _park.UpdateAuto(321, "PassengersQuantity", 3);
        }


        [TestMethod]
        [ExpectedException(typeof(UpdateAutoException))]
        public void UpdateAutoWithWrongParameter()
        {
            _park.UpdateAuto(_park.Vehicles[1].Id, "PassengersQuantityTi", 3);
        }


        [TestMethod]
        [ExpectedException(typeof(InitializationException))]
        public void UpdateAutoWithWrongValue()
        {
            _park.UpdateAuto(_park.Vehicles[1].Id, "PassengersQuantity", 33);
        }


        [TestMethod]
        public void UpdateAutoWithCorrectInputs()
        {
            PassengerCar car = (PassengerCar)_park.Vehicles[1];
            _park.UpdateAuto(_park.Vehicles[1].Id, "PassengersQuantity", 3);
            Assert.AreEqual(3, car.PassengersQuantity);
        }


        [TestMethod]
        [ExpectedException(typeof(RemoveAutoException))]
        public void RemoveAutoByWrongId()
        {
            _park.RemoveAutoById(32);
        }


        [TestMethod]
        public void RemoveVehicleByCorrectId()
        {
            _park.RemoveAutoById(_park.Vehicles[2].Id);
            Assert.AreEqual(3, _park.Vehicles.Count);
        }
    }
}
