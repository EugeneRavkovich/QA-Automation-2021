using System;

namespace Autopark
{
    [Serializable]
    public class Chassis
    {
        /// <summary>
        /// Chassis wheels quantity
        /// </summary>
        public int WheelsQuantity { get; set; }

        /// <summary>
        /// Chassis serial number
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Permissible load, measured in tonns
        /// </summary>
        public double PermissibleLoad { get; set; }


        /// <summary>
        /// Constructor w/o parameters
        /// </summary>
        public Chassis() { }


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="wheelsQuantity">Chassis wheels quantity</param>
        /// <param name="serialNumber">Serial number of chassis</param>
        /// <param name="permissibleLoad">Chassis permissible load</param>
        public Chassis(int wheelsQuantity, string serialNumber, double permissibleLoad) 
        {
            this.WheelsQuantity = wheelsQuantity;
            this.SerialNumber = serialNumber;
            this.PermissibleLoad = permissibleLoad;
        }


        /// <summary>
        /// Casting a chassis object to a string
        /// </summary>
        /// <returns>Chassis object as a string</returns>
        public override string ToString()
        {
            return $"Number of wheels: {WheelsQuantity}, Serial number: {SerialNumber}, Permissible load: {PermissibleLoad} tonns";
        }
    }
}
