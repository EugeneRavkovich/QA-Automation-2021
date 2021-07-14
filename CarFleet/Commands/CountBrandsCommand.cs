using System;

namespace CarFleet
{
    /// <summary>
    /// Class that defines a command for counting the number of cars
    /// of specified brand in the car fleet
    /// </summary>
    class CountBrandsCommand: ICommand
    {
        /// <summary>
        /// The current state of the CarFleet class object
        /// </summary>
        private CarFleet _fleet;


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        public CountBrandsCommand()
        {
            this._fleet = CarFleet.GetFleet();
        }


        /// <summary>
        /// Method for executing the current command
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(_fleet.CountBrands());
        }
    }
}