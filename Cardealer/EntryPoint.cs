using System;
using System.Collections.Generic;
using System.Linq;

namespace Cardealer
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(Brand.Tesla, "X", BodyType.Coupe, EngineType.Electric, 1.6, 23100);
            Car car2 = new Car(Brand.Tesla, "Y", BodyType.Sedan, EngineType.Electric, 2.0, 26000);
            Car car3 = new Car(Brand.Mazda, "3", BodyType.Sedan, EngineType.Petrol, 1.8, 11000);
            Car car4 = new Car(Brand.BMW, "e30", BodyType.Sedan, EngineType.Petrol, 3.2, 3500);
            List<Car> cars = new List<Car> { car1, car2, car3, car4 };
            CarDealer dealer = new CarDealer(cars);

            Func<Car, double> price = x => x.Price;
            Func<Car, double> engineCapacity = x => x.EngineCapacity;
            Console.WriteLine(dealer.GetAverage(price));
            Console.WriteLine(dealer.GetAverage(engineCapacity));

            Func<Car, bool> countBrand1 = x => x.Price > 10000 && x.Brand == Brand.Tesla;
            Func<Car, bool> countBrand2 = x => x.BodyType == BodyType.Sedan;
            Func<Car, bool> countBrand3 = x => x.EngineCapacity < 3;
            Console.WriteLine(dealer.GetCount(countBrand1));
            Console.WriteLine(dealer.GetCount(countBrand2));
            Console.WriteLine(dealer.GetCount(countBrand3));

            Console.WriteLine(dealer.GetMaxValue(price));
            Console.WriteLine(dealer.GetMaxValue(engineCapacity));
           
            var selected1 = cars.Where(x => x.Price > 10000 && x.Brand == Brand.Tesla).Count();
            var selected2 = cars.Where(x => x.BodyType == BodyType.Sedan).Count();
            var selected3 = cars.Where(x => x.EngineCapacity < 3).Count();
        }
    }
}
