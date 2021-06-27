using System;
using System.Xml.Serialization;

namespace Autopark
{
    [XmlInclude(typeof(PassengerCar))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Scooter))]
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
            this.Engine = engine;
            this.Chassis = chassis;
            this.Transmission = transmission;
            
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
