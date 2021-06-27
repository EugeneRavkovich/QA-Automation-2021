using System;

namespace Autopark
{
    [Serializable]
    public class Engine
    {
        /// <summary>
        /// Engine power, measured in hp
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Engine volume, measured in litres
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// Engine type
        /// </summary>
        public EngineType Type { get; set; }

        /// <summary>
        /// Engine serial number
        /// </summary>
        public string SerialNumber { get; set; }


        /// <summary>
        /// Constructor w/o parameters
        /// </summary>
        public Engine() { }


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
