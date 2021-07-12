using System.Collections.Generic;
using System.Linq;

namespace CarFleet
{
    class CarFleet
    {
        private static CarFleet _fleet;

        public List<Car> park;


        private CarFleet()
        {
            this.park = new List<Car>();
        }


        public static CarFleet GetFleet()
        {
            if (_fleet is null)
            {
                _fleet = new CarFleet();
            }
            return _fleet;
        }


        public void Add(Car car)
        {
            for (int i = 0; i < car.Quantity; i++)
            {
                park.Add(car);
            }
        }


        public int CountBrands()
        {
            return park.Select(x => x.Brand).Distinct().Count();
        }


        public int CountAll()
        {
            return park.Count;
        }


        public double GetAveragePrice()
        {
            if (park.Count == 0)
            {
                return 0;
            }
            return park.Sum(x => x.Price) / (double)park.Count;
        }


        public double GetAveragePriceByBrand(string brand)
        {
            var selection = park.Where(x => x.Brand == brand).ToList();
            if (selection.Count == 0)
            {
                return 0;
            }
            return selection.Sum(x => x.Price) / (double)selection.Count;
        }
    }
}