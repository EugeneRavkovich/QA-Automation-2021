using System;

namespace InterfacesAndAbstractClasses
{
    /// <summary>
    /// Class that defines a plane object
    /// </summary>
    public class Plane: IFlyable
    {
        private readonly int _startSpeed = 200;
        private readonly int _speedIncrement = 10;
        private readonly int _speedIncrementDistance = 10;

        /// <summary>
        /// Plane's tank capacity, measured in litres
        /// </summary>
        private double _tankCapacity;

        /// <summary>
        /// Plane's fuel consumption, measured in litres per thousand kilometers
        /// </summary>
        private double _fuelConsumption;

        /// <summary>
        /// Plane's maximum speed, measured in km/h
        /// </summary>
        private double _maxSpeed;

        /// <summary>
        /// Current position of a plane
        /// </summary>
        public Coordinate CurrentPosition { get; private set; }

        /// <summary>
        /// Method for setting and getting the _tankCapacity field value
        /// </summary>
        public double TankCapacity 
        {
            get 
            {
                return _tankCapacity;
            }
            private set 
            {
                if (value <= 0) 
                {
                    throw new ArgumentException($"{this.GetType()}: Tank capacity must be greater than 0");
                }
                _tankCapacity = value;
            }
        }

        /// <summary>
        /// Method for setting and getting the _fuelConsumption field value
        /// </summary>
        public double FuelConsumption 
        {
            get 
            {
                return _fuelConsumption;
            }
            private set
            {
                if (value <= 0) 
                {
                    throw new ArgumentException($"{this.GetType()}: Fuel consumption must be greater than 0");
                }
                _fuelConsumption = value;
            }
        }

        /// <summary>
        /// Method for setting and getting the _maxSpeed field value
        /// </summary>
        public double MaxSpeed 
        {
            get 
            {
                return _maxSpeed;    
            }
            private set
            {
                if (value < _startSpeed) 
                {
                    throw new ArgumentException($"{this.GetType()}: The maximum speed can't be less than start speed");
                }
                _maxSpeed = value;
            } 
        }


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="currentPosition">Current position of a plane</param>
        /// <param name="tankCapacity">Plane's tank capacity</param>
        /// <param name="fuelConsumption">Plane's fuels consumption</param>
        /// <param name="maxSpeed">Plane's maximum speed</param>
        public Plane(Coordinate currentPosition, double tankCapacity, 
                     double fuelConsumption, double maxSpeed)
        {
            this.CurrentPosition = currentPosition;
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.MaxSpeed = maxSpeed;
        }


        /// <summary>
        /// Changing the position of a plane if possible
        /// </summary>
        /// <param name="nextPoint">Destination point</param>
        public void FlyTo(Coordinate nextPoint) 
        {
            if (IsCanFlyTo(nextPoint))
            {
                CurrentPosition = nextPoint;
            }
            else
            {
                throw new ArgumentException("Not enough fuel");
            }
        
        }


        /// <summary>
        /// Calculating the flight time
        /// </summary>
        /// <param name="nextPoint">Destination point</param>
        /// <returns>Flight time</returns>
        public TimeSpan GetFlyTime(Coordinate nextPoint) 
        {
            if (!IsCanFlyTo(nextPoint)) 
            {
                throw new ArgumentException("Not enough fuel");
            }
            double wholeDistance = CurrentPosition.CalculateDistance(nextPoint);
            double currentDistance = 0;
            int currentSpeed = _startSpeed;
            double time = 0;
            while (wholeDistance - currentDistance > double.Epsilon) 
            {
                currentDistance += _speedIncrementDistance;
                time += (double)_speedIncrementDistance / currentSpeed;
                if (currentSpeed < MaxSpeed) 
                {
                    currentSpeed += _speedIncrement;
                }
            }
            time -= (currentDistance - wholeDistance) / currentSpeed;
            return TimeSpan.FromHours(time);
        }


        /// <summary>
        /// Checks the possibility of flying to provided point
        /// </summary>
        /// <param name="nextPoint">Destination point</param>
        /// <returns>The ability to overcome that distance</returns>
        public bool IsCanFlyTo(Coordinate nextPoint) 
        {
            return (TankCapacity / FuelConsumption) * 1000 >=
                    CurrentPosition.CalculateDistance(nextPoint);
        }
    }
}
