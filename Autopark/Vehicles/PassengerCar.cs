using System;

namespace Autopark
{
    [Serializable]
    public class PassengerCar: Vehicle
    {
        /// <summary>
        /// Passengers quantity that car can accommodate
        /// </summary>
        public int PassengersQuantity { get; set; }


        /// <summary>
        /// Constructor w/o parameters
        /// </summary>
        public PassengerCar() { }


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="engine">Car engine</param>
        /// <param name="chassis">Car chassis</param>
        /// <param name="transmission">Car transmission</param>
        /// <param name="passengersQuantity">Passengers quantity that car can accommodate</param>
        public PassengerCar(Engine engine, Chassis chassis, Transmission transmission, int passengersQuantity)
            : base(engine, chassis, transmission) => this.PassengersQuantity = passengersQuantity;


        /// <summary>
        /// Casting a car object to a string
        /// </summary>
        /// <returns>Car object as a string</returns>
        public override string ToString()
        {
            return base.ToString() + $"\nMax number of passengers: {PassengersQuantity}\n";
        }
    }
}
