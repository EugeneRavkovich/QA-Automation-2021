using System;

namespace Autopark
{
    [Serializable]
    public class Scooter: Vehicle
    {
        /// <summary>
        /// Scooter maximum speed, measured in km/h
        /// </summary>
        public int MaxSpeed { get; set; }


        /// <summary>
        /// Constructor w/o parameters
        /// </summary>
        public Scooter() { }


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="engine">Scooter engine</param>
        /// <param name="chassis">Scooter chassis</param>
        /// <param name="transmission">Scooter transmission</param>
        /// <param name="maxSpeed">Scooter maximum speed</param>
        public Scooter(Engine engine, Chassis chassis, Transmission transmission, int maxSpeed)
            : base(engine, chassis, transmission) => this.MaxSpeed = maxSpeed;


        /// <summary>
        /// Casting a scooter object to a string
        /// </summary>
        /// <returns>Scooter object as a string</returns>
        public override string ToString()
        {
            return base.ToString() + $"\nMax speed: {MaxSpeed}\n";
        }
    }
}
