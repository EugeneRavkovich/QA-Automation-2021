using System;

namespace VehicleFleet
{
    /// <summary>
    /// Class that defines a chassis object
    /// </summary>
    [Serializable]
    public class Chassis
    {
        /// <summary>
        /// Chassis wheels quantity
        /// </summary>
        private int _wheelsQuantity;

        /// <summary>
        /// Permissible load, measured in tonns
        /// </summary>
        private double _permissibleLoad;

        /// <summary>
        /// Method for setting and getting the _wheelsQuantity field value
        /// </summary>
        public int WheelsQuantity
        {
            get
            {
                return _wheelsQuantity;
            }
            set
            {
                if (value < 2) 
                {
                    throw new ArgumentException($"{this.GetType()}: There can't be less than 2 wheels");
                }
                _wheelsQuantity = value;
            }
        }

        /// <summary>
        /// Method for setting and getting the _permissiobleLoad field value
        /// </summary>
        public double PermissibleLoad
        {
            get
            {
                return _permissibleLoad;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{this.GetType()}: permissible load must be greater than 0");
                }
                _permissibleLoad = value;
            }
        }

        /// <summary>
        /// Chassis serial number
        /// </summary>
        public string SerialNumber { get; set; }


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