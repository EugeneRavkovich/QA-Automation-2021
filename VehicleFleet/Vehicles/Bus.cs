namespace VehicleFleet
{
    /// <summary>
    /// Class that defines a bus object
    /// </summary>
    public class Bus : Vehicle
    {
        /// <summary>
        /// Bus route number
        /// </summary>
        public string RouteNumber { get; set; }


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="engine">Bus engine</param>
        /// <param name="chassis">Bus chassis</param>
        /// <param name="transmission">Bus transmission</param>
        /// <param name="routeNumber">Bus route number</param>
        public Bus(Engine engine, Chassis chassis, Transmission transmission, string routeNumber)
            : base(engine, chassis, transmission) => this.RouteNumber = routeNumber;


        /// <summary>
        /// Casting a bus object to a string
        /// </summary>
        /// <returns>Bus object as a string</returns>
        public override string ToString()
        {
            return base.ToString() + $"\nRoute number: {RouteNumber}\n";
        }
    }
}
