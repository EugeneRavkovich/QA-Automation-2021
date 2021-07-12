namespace CarFleet
{
    /// <summary>
    /// Class that defines a command for adding a new car object to the fleet
    /// </summary>
    class AddCommand: ICommand
    {
        /// <summary>
        /// Car for adding
        /// </summary>
        private Car _car;

        /// <summary>
        /// The current state of the CarFleet class object
        /// </summary>
        private CarFleet _fleet;


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="car">Car instance for adding</param>
        public AddCommand(Car car)
        {
            this._car = car;
            this._fleet = CarFleet.GetFleet();
        }


        /// <summary>
        /// Method for executing the current command
        /// </summary>
        public void Execute()
        {
            _fleet.Add(_car);
        }
    }
}