using System;

namespace VehicleFleet
{
    /// <summary>
    /// Class that defines a passenger car object
    /// </summary>
    public class PassengerCar : Vehicle
    {
        /// <summary>
        /// Passengers quantity that car can accommodate
        /// </summary>
        private int _passengersQuantity;

        /// <summary>
        /// Method for setting and getting the _passengersQuantity field value
        /// </summary>
        public int PassengersQuantity 
        {
            get 
            {
                return _passengersQuantity;    
            }
            set 
            {
                if (value < 0 || value > 4) 
                {
                    throw new ArgumentException($"{this.GetType()}: Passenger car can carry up to 4 passengers");
                }
                _passengersQuantity = value;
            }
        }


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
