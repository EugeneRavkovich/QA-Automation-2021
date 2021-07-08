using System.Collections.Generic;
using System.Linq;
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
        /// Constructor w/o parameters
        /// </summary>
        public VehicleFleet() { }


        /// <summary>
        /// Constructor for initializing class field
        /// </summary>
        /// <param name="vehicles"></param>
        public VehicleFleet(List<Vehicle> vehicles) => this.Vehicles = vehicles;


        /// <summary>
        /// Forming a sample of vehicles with an engine capacity greater than
        /// provided value
        /// </summary>
        /// <param name="volumeLoverLimit"></param>
        /// <returns>List of vehicles</returns>
        public List<Vehicle> GetVehiclesWithEngineVolumeGreaterThan(double volumeLoverLimit) 
        {
            if (Vehicles is null)
            {
                return new List<Vehicle>();
            }

            return (from vehicle in Vehicles
                    where vehicle.Engine.Volume > volumeLoverLimit
                    select vehicle).ToList();
        }


        /// <summary>
        /// Forming a sample of engines of busses and trucks
        /// </summary>
        /// <returns>List of engines</returns>
        public List<Engine> GetEnginesOfBussesAndTrucks() 
        {
            if (Vehicles is null)
            {
                return new List<Engine>();
            }

            return (from vehicle in Vehicles
                    where vehicle is Bus || vehicle is Truck
                    select vehicle.Engine).ToList();
        }


        /// <summary>
        /// Forming a sample of vehicles grouped by transmission
        /// </summary>
        /// <returns>List of vehicles</returns>
        public List<Vehicle> GroupByTransmission()
        {
            if (Vehicles is null)
            {
                return new List<Vehicle>();
            }

            return (from vehicle in Vehicles
                    group vehicle by vehicle.Transmission.Type into groups
                    from _group in groups.ToList()
                    select _group).ToList();
        }


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