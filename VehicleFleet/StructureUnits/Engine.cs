using System;

namespace VehicleFleet
{
    /// <summary>
    /// Class that defines an egine object
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Engine power, measured in hp
        /// </summary>
        private int _power;

        /// <summary>
        /// Engine volume, measured in litres
        /// </summary>
        private double _volume;

        /// <summary>
        /// Method for setting and getting the _power field value
        /// </summary>
        public int Power 
        {
            get 
            {
                return _power;    
            }
            set 
            {
                if (value <= 0) 
                {
                    throw new ArgumentException($"{this.GetType()}: Engine power must be greater than 0");
                }
                _power = value;
            }
        }

        /// <summary>
        /// Method for setting and getting the _volume field value
        /// </summary>
        public double Volume 
        { 
            get
            {
                return _volume;
            }
            set 
            {
                if (value <= 0) 
                {
                    throw new ArgumentException($"{this.GetType()}: Engine volume must be greater than 0");
                }
                _volume = value;
            }
        }

        /// <summary>
        /// Engine type
        /// </summary>
        public EngineType Type { get; set; }

        /// <summary>
        /// Engine serial number
        /// </summary>
        public string SerialNumber { get; set; }


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="power">Engines power</param>
        /// <param name="volume">Engine volume</param>
        /// <param name="type">Engine type</param>
        /// <param name="serialNumber">Engine serial number</param>
        public Engine(int power, double volume, EngineType type, string serialNumber)
        {
            this.Power = power;
            this.Volume = volume;
            this.Type = type;
            this.SerialNumber = serialNumber;
        }


        /// <summary>
        /// Casting an engine object to a string
        /// </summary>
        /// <returns>Engine object as a string</returns>
        public override string ToString()
        {
            return $"Power: {Power} HP, Volume: {Volume} l., Type: {Type}, Serial number: {SerialNumber}";
        }
    }
}
