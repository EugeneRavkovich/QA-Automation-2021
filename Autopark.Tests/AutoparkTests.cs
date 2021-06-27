using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autopark.Tests
{
    [TestClass]
    public class AutoparkTests
    {

        private static Bus _bus;
        private static PassengerCar _car;
        private static Scooter _scooter;
        private static Truck _truck;
        private static Autopark _park;


        [ClassInitialize]
        public static void ClassInitialize(TestContext context) 
        {
            _bus = new Bus(
                new Engine(160, 5.0, EngineType.Diesel, "I3333U"),
                new Chassis(8, "WQ222Q", 22),
                new Transmission(TransmissionType.Automatic, 7, "Jatko"), "144c");

            _car = new PassengerCar(
                new Engine(230, 3.2, EngineType.Petrol, "E2415O"),
                new Chassis(4, "RT321Q", 2),
                new Transmission(TransmissionType.Automatic, 10, "Jatco"), 4);

            _truck = new Truck(
                new Engine(350, 5.0, EngineType.Petrol, "T2103I"),
                new Chassis(6, "QI857N", 15),
                new Transmission(TransmissionType.Mechanic, 7, "Jatco"), 12);

            _scooter = new Scooter(
                new Engine(60, 1.2, EngineType.Gas, "KW23121P"),
                new Chassis(4, "123121", 22),
                new Transmission(TransmissionType.Automatic, 4, "Jatko"), 120);

            

            _park = new Autopark(new List<Vehicle> { _car, _bus, _truck, _scooter });
        }


        [TestMethod]
        public void EngineVolumeMoreThanValueReturnCorrectQuantity()
        {
            Assert.AreEqual(3, _park.EngineVolumeMoreThan(2.0).Count);
        }


        [TestMethod]
        public void EngineVolumeMoreThanValueReturnCorrectType() 
        {
            Assert.AreEqual(true, _park.EngineVolumeMoreThan(1.5).TrueForAll(x => x.GetType().IsSubclassOf(typeof(Vehicle))));
            
        }


        [TestMethod]
        public void EnginesOfBussesAndTrucksReturnCorrectQuantity() 
        {
            Assert.AreEqual(2, _park.EnginesOfBussesAndTrucks().Count);
        }


        [TestMethod]
        public void EnginesOfBussesAndTrucksReturnCorrectType()
        {
            Assert.AreEqual(true, _park.EnginesOfBussesAndTrucks().TrueForAll(x => x.GetType() == typeof(Engine)));
        }


        [TestMethod]
        public void GroupedByTransmissionReturnCorrectType() 
        {
            Assert.AreEqual(true, _park.GroupedByTransmission().TrueForAll(x => x.GetType().IsSubclassOf(typeof(Vehicle))));
        }


        [TestMethod]
        public void GroupedByTransmission() 
        {
            var order = (from vehicle in _park.GroupedByTransmission()
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
