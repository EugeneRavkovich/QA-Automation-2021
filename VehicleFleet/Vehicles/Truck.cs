using System;

namespace VehicleFleet
{
    /// <summary>
    /// Class that defines a truck object
    /// </summary>
    public class Truck : Vehicle
    {
        /// <summary>
        /// The maximum load capacity of the truck, measured in tonns
        /// </summary>
        private double _loadCapacity;

        /// <summary>
        /// Method for setting and getting the _loadCapacity field value
        /// </summary>
        public double LoadCapacity 
        {
            get 
            {
                return _loadCapacity;
            }
            set 
            {
                if (value <= 0 || value > 30) 
                {
                    throw new ArgumentException($"{this.GetType()}: Truck can carry cargo weighing up to 30 tonns");
                }
                _loadCapacity = value;
            }
        }


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="engine">Truck engine</param>
        /// <param name="chassis">Truck chassis</param>
        /// <param name="transmission">Truck transmission</param>
        /// <param name="loadCapacity">Truck load capacity</param>
        public Truck(Engine engine, Chassis chassis, Transmission transmission, double loadCapacity)
            : base(engine, chassis, transmission) => this.LoadCapacity = loadCapacity;


        /// <summary>
        /// Casting a truck object to a string
        /// </summary>
        /// <returns>Truck object as a string</returns>
        public override string ToString()
        {
            return base.ToString() + $"\nMax carrying capacity: {LoadCapacity}\n";
        }
    }
}
