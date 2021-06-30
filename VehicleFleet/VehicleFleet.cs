using System.Collections.Generic;
using System.Text;

namespace VehicleFleet
{
    /// <summary>
    /// Class that defines a vehicle fleet object.
    /// Vehicle fleet contains vehicles of various types
    /// </summary>
    public class VehicleFleet
    {
        /// <summary>
        /// List of vehicles in the autopark
        /// </summary>
        public List<Vehicle> Vehicles { get; set; }


        /// <summary>
        /// Constructor for initializing class field
        /// </summary>
        /// <param name="vehicles"></param>
        public VehicleFleet(List<Vehicle> vehicles) => this.Vehicles = vehicles;


        /// <summary>
        /// Custing an autopark object to a string
        /// </summary>
        /// <returns>Autopark object as a string</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (Vehicle vehicle in Vehicles)
            {
                output.Append(vehicle.ToString() + "\n");
            }
            return output.ToString();
        }
    }
}
