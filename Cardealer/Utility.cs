using System;

namespace Cardealer
{
     public static class Utility
    {
        /// <summary>
        /// Finds the maximum value of any parameter
        /// identified by the gelegate
        /// </summary>
        /// <param name="dealer">CarDealer object</param>
        /// <param name="field">Parameter by which method will search
        /// for the maximum value</param>
        /// <returns>Maximum value</returns>
        public static double GetMaxValue(this CarDealer dealer, Func<Car, double> field) 
        {
            double maxValue = 0;
            foreach (Car car in dealer.cars) 
            {
                if (field(car) > maxValue) 
                {
                    maxValue = field(car);
                }
            }
            return maxValue;
        } 
    }
}
