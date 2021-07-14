using System.Collections.Generic;
using System.Linq;

namespace CarFleet
{
    /// <summary>
    /// Class that defines a car fleet object
    /// </summary>
    class CarFleet
    {
        /// <summary>
        /// An instance of current class
        /// </summary>
        private static CarFleet _fleet;

        /// <summary>
        /// List of cars in the fleet
        /// </summary>
        public List<Car> park;


        /// <summary>
        /// Private constructor w/o parameters
        /// </summary>
        private CarFleet()
        {
            this.park = new List<Car>();
        }


        /// <summary>
        /// Method for getting an object of the class in the current state
        /// </summary>
        /// <returns>CarFleet object</returns>
        public static CarFleet GetFleet()
        {
            if (_fleet is null)
            {
                _fleet = new CarFleet();
            }
            return _fleet;
        }


        /// <summary>
        /// Method for adding a car to the list of cars
        /// </summary>
        /// <param name="car">Car for adding</param>
        public void Add(Car car)
        {
            for (int i = 0; i < car.Quantity; i++)
            {
                park.Add(car);
            }
        }


        /// <summary>
        /// Counts the total number of brands
        /// </summary>
        /// <returns>Brands quantity</returns>
        public int CountBrands()
        {
            return park.Select(x => x.Brand).Distinct().Count();
        }


        /// <summary>
        /// Counts the number of all cars
        /// </summary>
        /// <returns>Cars quantity</returns>
        public int CountAll()
        {
            return park.Count;
        }


        /// <summary>
        /// Calculates the average price of all cars
        /// </summary>
        /// <returns>Average price of all cars</returns>
        public double GetAveragePrice()
        {
            if (park.Count == 0)
            {
                return 0;
            }
            return park.Sum(x => x.Price) / (double)park.Count;
        }


        /// <summary>
        /// Calculates the average price of cars of specified brand
        /// </summary>
        /// <param name="brand">Car brand for forming a sample</param>
        /// <returns>Average price of cars of specified brand</returns>
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