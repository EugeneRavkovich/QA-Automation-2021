using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autopark
{
     public class Autopark
    {
        /// <summary>
        /// List of vehicles in the autopark
        /// </summary>
        public List<Vehicle> Vehicles { get; set; }


        /// <summary>
        /// Constructor w/o parameters
        /// </summary>
        public Autopark() { }


        /// <summary>
        /// Constructor for initializing class field
        /// </summary>
        /// <param name="vehicles"></param>
        public Autopark(List<Vehicle> vehicles) => this.Vehicles = vehicles;


        /// <summary>
        /// A selection of vehicles with engine volume more than 1.5
        /// </summary>
        /// <param name="volumeLoverLimit"></param>
        /// <returns>List of vehicles</returns>
        public List<Vehicle> EngineVolumeMoreThan(double volumeLoverLimit) 
        {
            return (from vehicle in Vehicles
                    where vehicle.Engine.Volume > volumeLoverLimit
                    select vehicle).ToList();

        }


        /// <summary>
        /// A selection of engines of busses and trucks 
        /// </summary>
        /// <returns>List of engines</returns>
        public List<Engine> EnginesOfBussesAndTrucks()
        {
            return (from vehicle in Vehicles
                   where vehicle is Bus || vehicle is Truck
                   select vehicle.Engine).ToList(); 
        }


        /// <summary>
        /// A selection of vehicles grouped by transmission type
        /// </summary>
        /// <returns>List of Vehicle</returns>
        public List<Vehicle> GroupedByTransmission()
        {
            return (from vehicle in Vehicles
                    group vehicle by vehicle.Transmission.Type into transmissionGroups
                    from transmissionGroup in transmissionGroups.ToList()
                    select transmissionGroup).ToList();
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
