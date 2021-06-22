using System;
using System.Collections.Generic;

namespace Cardealer
{
    public class CarDealer
    {
        public List<Car> cars;


        public CarDealer(List<Car> cars) 
        {
            this.cars = cars;
        }


        /// <summary>
        /// Calculates the average value of a certain parameter
        /// identified by the delegate
        /// </summary>
        /// <param name="field"></param>
        /// <returns>Average value</returns>
        public double GetAverage(Func<Car, double> field) 
        {
            double totalValue = 0;
            foreach(Car car in cars) 
            {
                totalValue += field(car);
            }
            return totalValue / cars.Count;
        }


        /// <summary>
        /// Calculates the number of objects corresponding to some conditions
        /// identified by the delegate
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>Number of objects</returns>
        public int GetCount(Func<Car, bool> condition)
        {
            int counter = 0;
            foreach (Car car in cars) 
            {
                if (condition(car)) 
                {
                    counter++;
                }
            }
            return counter;
        }
    } 
}
