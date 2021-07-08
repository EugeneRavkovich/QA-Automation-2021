using System;
using System.Xml.Serialization;

namespace VehicleFleet
{
    /// <summary>
    /// Class that defines the entity of the vehicle for inheritance
    /// </summary>
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(PassengerCar))]
    [XmlInclude(typeof(Scooter))]
    [XmlInclude(typeof(Truck))]
    [Serializable]
    public abstract class Vehicle
    {
        /// <summary>
        /// Vehicle engine
        /// </summary>
        public Engine Engine { get; set; }

        /// <summary>
        /// Vehicle chassis
        /// </summary>
        public Chassis Chassis { get; set; }

        /// <summary>
        /// Vehicle transmission
        /// </summary>
        public Transmission Transmission { get; set; }


        /// <summary>
        /// Constructor w/o parameters
        /// </summary>
        public Vehicle() { }


        /// <summary>
        /// Cunstructor for initializing class fields
        /// </summary>
        /// <param name="engine">Vehicle engine</param>
        /// <param name="chassis">Vehicle chassis</param>
        /// <param name="transmission">Vehicle transmission</param>
        public Vehicle(Engine engine, Chassis chassis, Transmission transmission)
        {
            this.Engine = engine ?? throw new InitializationException("The vehicle must contain an engine");
            this.Chassis = chassis ?? throw new InitializationException("The vehicle must contain a chassis");
            this.Transmission = transmission ?? throw new InitializationException("The vehicle must contain a transmission") ;
        }


        /// <summary>
        /// Casting a vehicle object to a string
        /// </summary>
        /// <returns>Vehicle object as a string</returns>
        public override string ToString()
        {
            return $"\t\t{this.GetType().Name}\nEngine:\n \t{Engine}\nChassis:\n \t{Chassis}\nTransmission:\n \t{Transmission}";
        }
    }
}