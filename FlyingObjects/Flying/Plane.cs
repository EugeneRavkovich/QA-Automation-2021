using System;

namespace InterfacesAndAbstractClasses
{
    class Plane: IFlyable
    {
        private readonly int _startSpeed = 200;
        private readonly int _speedIncrement = 10;
        private readonly int _speedIncrementDistance = 10;

        /// <summary>
        /// Current position of a plane
        /// </summary>
        public Coordinate CurrentPosition { get; private set; }

        /// <summary>
        /// Plane's tank capacity, measured in litres
        /// </summary>
        public double TankCapacity { get; private set; }

        /// <summary>
        /// Plane's fuel consumption, measured in litres per thousand kilometers
        /// </summary>
        public double FuelConsumption { get; private set; }

        /// <summary>
        /// Plane's maximum speed, measured in km/h
        /// </summary>
        public double MaxSpeed { get; private set; }


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
                throw new Exception("Not enough fuel");
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
        private bool IsCanFlyTo(Coordinate nextPoint) 
        {
            return (TankCapacity / FuelConsumption) * 1000 -
                   CurrentPosition.CalculateDistance(nextPoint) >= double.Epsilon;
        }
    }
}
