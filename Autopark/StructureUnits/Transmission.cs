using System;

namespace Autopark
{
    [Serializable]
    public class Transmission
    {
        /// <summary>
        /// Transmission type
        /// </summary>
        public TransmissionType Type { get; set; }

        /// <summary>
        /// Gears quantity
        /// </summary>
        public int GearsQuantity { get; set; }

        /// <summary>
        /// Transmission manufacturer
        /// </summary>
        public string Manufacturer { get; set; }

        
        /// <summary>
        /// Constructor w/o parameters
        /// </summary>
        public Transmission() { }


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="type">Transmission type</param>
        /// <param name="gearsQuantity">Gears quntity</param>
        /// <param name="manufacturer">Transmission manufacturer</param>
        public Transmission(TransmissionType type, int gearsQuantity, string manufacturer) 
        {
            this.Type = type;
            this.GearsQuantity = gearsQuantity;
            this.Manufacturer = manufacturer;
        }


        /// <summary>
        /// Casting a transmission object to a string
        /// </summary>
        /// <returns>Transmission object as a string</returns>
        public override string ToString()
        {
            return $"Transmission type: {Type}, Number of gears: {GearsQuantity}, Manufacturer: {Manufacturer}";
        }
    }
}
