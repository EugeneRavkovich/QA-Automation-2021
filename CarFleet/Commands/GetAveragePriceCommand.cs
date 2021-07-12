using System;

namespace CarFleet
{
    /// <summary>
    /// Class that defines a method for counting the average price
    /// of all cars in the car fleet
    /// </summary>
    class GetAveragePriceCommand: ICommand
    {
        /// <summary>
        /// The current state of the CarFleet class object
        /// </summary>
        private CarFleet _fleet;


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        public GetAveragePriceCommand()
        {
            this._fleet = CarFleet.GetFleet();
        }


        /// <summary>
        /// Method for executing the current command
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(_fleet.GetAveragePrice());
        }
    }
}