using System;

namespace InterfacesAndAbstractClasses
{
    public class Drone: IFlyable
    {
        private readonly double _stopPeriod = 1d / 6;
        private readonly double _stopTime = 1d / 60;

        /// <summary>
        /// Current position of a drone
        /// </summary>
        public Coordinate CurrentPosition { get; private set; }

        /// <summary>
        /// The maximum distance that drone can cover, measured in km
        /// </summary>
        public double MaxDistance { get; set; }

        /// <summary>
        /// Drone's speed, measured in km/h
        /// </summary>
        public double Speed { get; set; }


        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="currentPosition">Current position of a drone</param>
        /// <param name="maxDistance">The maximum distance that drone can cover</param>
        /// <param name="speed">Drone's speed</param>
        public Drone(Coordinate currentPosition, double maxDistance, double speed) 
        {
            this.CurrentPosition = currentPosition;
            this.MaxDistance = maxDistance;
            this.Speed = speed;
        }


        /// <summary>
        /// Changing the position of a drone if possible
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
                throw new ArgumentException("Drone can't fly that far");
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
                throw new ArgumentException("Drone can't fly that far");
            }
            double wholeDistance = CurrentPosition.CalculateDistance(nextPoint);
            double currentDistance = 0;
            double time = 0;
            while (wholeDistance - currentDistance > double.Epsilon)
            {
                currentDistance += _stopPeriod * Speed;
                time += _stopPeriod + _stopTime; ;

            }
            if (time > 0)
            {
                time -= _stopTime;
            }
            time -= Math.Abs(currentDistance - wholeDistance) / Speed;
            
            return TimeSpan.FromHours(time);
        }


        /// <summary>
        /// Checks the possibility of flying to provided point
        /// </summary>
        /// <param name="nextPoint">Destination point</param>
        /// <returns>The ability to overcome that distance</returns>
        public bool IsCanFlyTo(Coordinate nextPoint)
        {
            return MaxDistance >= CurrentPosition.CalculateDistance(nextPoint) &&
                   Speed > 0;
        }
    }
}
