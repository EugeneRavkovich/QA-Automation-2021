using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Cardealer.Tests
{
    [TestClass]
    public class CarDealerTests
    {
        readonly static Car car1 = new Car(Brand.Tesla, "X", BodyType.Coupe, EngineType.Electric, 200, 23100);
        readonly static Car car2 = new Car(Brand.Tesla, "Y", BodyType.Sedan, EngineType.Electric, 212, 26000);
        readonly static Car car3 = new Car(Brand.Mazda, "3", BodyType.Sedan, EngineType.Petrol, 1.8, 11000);
        readonly static Car car4 = new Car(Brand.BMW, "e30", BodyType.Sedan, EngineType.Petrol, 3.2, 35000);
        readonly static Car car5 = new Car(Brand.Acura, "XYZ", BodyType.Hatchback, EngineType.Gas, 1.6, 9100);
        readonly static Car car6 = new Car(Brand.Audi, "R8", BodyType.Sedan, EngineType.Petrol, 4.4, 120000);
        readonly static Car car7 = new Car(Brand.Chevrolet, "Camaro", BodyType.Coupe, EngineType.Petrol, 3.6, 34800);
        readonly static CarDealer dealer = new CarDealer(new List<Car> { car1, car2, car3, car4, car5, car6, car7 });


        [TestMethod]
        public void GetAveragePricePositive()
        {
            Assert.AreEqual(37000, dealer.GetAverage(x => x.Price));
        }


        [TestMethod]
        public void GetCountPriceMoreThan30000Positive()
        {
            Assert.AreEqual(3, dealer.GetCount(x => x.Price > 30000));
        }


        [TestMethod]
        public void GetCountEngineCapacityLessThan2Posititve() 
        {
            Assert.AreEqual(2, dealer.GetCount(x => x.EngineCapacity < 2));
        }


        [TestMethod]
        public void GetMaxPricePositive() 
        {
            Assert.AreEqual(120000, dealer.GetMaxValue(x => x.Price));
        }
    }
}
