using System;

namespace VehicleFleet
{
    /// <summary>
    /// Class that defines a transmission object
    /// </summary>
    [Serializable]
    public class Transmission
    {
        /// <summary>
        /// Gears quantity
        /// </summary>
        private int _gearsQuantity;

        /// <summary>
        /// Method for setting and getting the _gearsQuantity field value
        /// </summary>
        public int GearsQuantity
        {
            get
            {
                return _gearsQuantity;
            }
            set
            {
                if (value < 3)
                {
                    throw new ArgumentException($"{this.GetType()}: Transmission can't have less than 3 gears");
                }
                _gearsQuantity = value;
            }
        }

        /// <summary>
        /// Transmission type
        /// </summary>
        public TransmissionType Type { get; set; }

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