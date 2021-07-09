using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Reflection;

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
        /// Add a new vehicle to the list of vehicles
        /// </summary>
        /// <param name="vehicle">Vehicle to add</param>
        public void Add(Vehicle vehicle)
        {
            if (IsExists(vehicle.Id))
            {
                throw new AddException("Vehicle with such id already exists");
            }
            else if (vehicle.Engine.Type == EngineType.Electric)
            {
                throw new AddException("This vehicle fleet doesn't sell electric cars");
            }
            Vehicles.Add(vehicle);
        }


        /// <summary>
        /// Checks whether a vehicle with such id already exists
        /// </summary>
        /// <param name="id">Id of a vehicle</param>
        /// <returns>True if exists, otherwise false</returns>
        private bool IsExists(int id)
        {
            return Vehicles.Select(x => x.Id).Contains(id);
        }


        /// <summary>
        /// Forming a sample of vehicles for which the value of the specified
        /// parameter is equal to the specified value
        /// </summary>
        /// <param name="parameter">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns>List of vehicles</returns>
        public List<Vehicle> GetAutoByParameter(string parameter, string value)
        {
            if (!GetAllParameters().Contains(parameter))
            {
                throw new GetAutoByParameterException("Wrong parameter");
            }
            return Vehicles.Where(x => GetParameterValue(x, parameter) == value).ToList();
        }


        /// <summary>
        /// Forming a sample of all parameters of all vehicles belonging to vehical fleet
        /// </summary>
        /// <returns>Set of parameters</returns>
        private List<string> GetAllParameters()
        {
            return Vehicles.SelectMany(x => x.GetType().GetProperties()).Select(x => x.Name).Distinct().ToList();
        }


        /// <summary>
        /// Getting a parameter of a vehicle object by its name
        /// </summary>
        /// <param name="vehicle">Object in witch the parameter is being searched</param>
        /// <param name="parameter">Name of the desired parameter</param>
        /// <returns>PropertyInfo if provided parameter exists, else null</returns>
        private PropertyInfo GetParameterByName(Vehicle vehicle, string parameter)
        {
            return vehicle.GetType().GetProperty(parameter);
        }


        /// <summary>
        /// Getting the value of the specified parameter in provided vehicle object 
        /// </summary>
        /// <param name="vehicle">Object in witch the parameter is being searched</param>
        /// <param name="parameter">Name of the desired parameter</param>
        /// <returns>Parameter value in string form if parameter exists, otherwise null</returns>
        private string GetParameterValue(Vehicle vehicle, string parameter)
        {
            return GetParameterByName(vehicle, parameter)?.GetValue(vehicle).ToString();
        }


        /// <summary>
        /// Update the specified parameter of the vehicle with specified id with
        /// provided value
        /// </summary>
        /// <param name="id">Id of the vehicle object</param>
        /// <param name="parameter">Parameter name for updating</param>
        /// <param name="value">Value for updating the parameter</param>
        public void UpdateAuto(int id, string parameter, object value)
        {
            var vehicle = Vehicles.Find(x => x.Id == id) ??
                throw new UpdateAutoException("There is no vehicle with such id");
            var property = GetParameterByName(vehicle, parameter) ??
                throw new UpdateAutoException($"Vehicle of the {vehicle.GetType().Name}" +
                $" type doesn't have parameter {parameter}");
            try
            {
                property.SetValue(vehicle, value);
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }


        /// <summary>
        /// Removes the vehicle with provided id 
        /// </summary>
        /// <param name="id">Id of the vehicle to remove</param>
        public void RemoveAutoById(int id)
        {
            if (!IsExists(id))
            {
                throw new RemoveAutoException("There is no vehicle with such id");
            }
            Vehicles.Remove(Vehicles.Find(x => x.Id == id));
        }


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