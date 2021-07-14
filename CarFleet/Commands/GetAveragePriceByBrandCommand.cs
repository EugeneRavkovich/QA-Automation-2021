using System;

namespace CarFleet
{
    /// <summary>
    /// Class that defines a command for counting the average price of cars
    /// of specified brand in the car fleet
    /// </summary>
    class GetAveragePriceByBrandCommand: ICommand
    {
        /// <summary>
        /// The current state of the CarFleet class object
        /// </summary>
        private CarFleet _fleet;

        /// <summary>
        /// Car brand
        /// </summary>
        private string _brand;


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="brand">Car brand for forming a sample</param>
        public GetAveragePriceByBrandCommand(string brand)
        {
            this._fleet = CarFleet.GetFleet();
            this._brand = brand;
        }


        /// <summary>
        /// Method for executing the current command
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(_fleet.GetAveragePriceByBrand(_brand));
        }
    }
}