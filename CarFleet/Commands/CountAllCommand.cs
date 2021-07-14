using System;

namespace CarFleet
{
    /// <summary>
    /// Class that defines a command for counting the total number of cars
    /// in the car fleet
    /// </summary>
    class CountAllCommand: ICommand
    {
        /// <summary>
        /// The current state of the CarFleet class object
        /// </summary>
        private CarFleet _fleet;


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        public CountAllCommand()
        {
            this._fleet = CarFleet.GetFleet();
        }

        /// <summary>
        /// Method for executing the current command
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(_fleet.CountAll());
        }
    }
}