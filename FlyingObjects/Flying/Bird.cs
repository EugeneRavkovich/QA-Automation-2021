using System;

namespace InterfacesAndAbstractClasses
{
    public class Bird: IFlyable
    {
        readonly int _restoreTime = 1;

        /// <summary>
        /// Current position of a bird
        /// </summary>
        public Coordinate CurrentPosition { get; private set; }

        /// <summary>
        /// Bird's speed, measured in km/h
        /// </summary>
        public float Speed { get;  set; }

        /// <summary>
        /// The maximum distance that bird can cover, measured in km
        /// </summary>
        public double MaxDistance { get; private set; }
        

        /// <summary>
        /// Constructor for initializing class fields
        /// </summary>
        /// <param name="currentPosition">Current position of a bird</param>
        /// <param name="maxDistance">The maximum distance that bird can cover</param>
        public Bird(Coordinate currentPosition, double maxDistance) 
        {
            this.CurrentPosition = currentPosition;
            this.Speed = new Random().Next(0, 200) / 10f;
            this.MaxDistance = maxDistance;
        }


        /// <summary>
        /// Changing the position of a bird if possible
        /// </summary>
        /// <param name="nextPoint">Destination point</param>
        public void FlyTo(Coordinate nextPoint) 
        {
            if (IsCanFlyTo(nextPoint))
            {
                this.CurrentPosition = nextPoint;
            }
            else 
            {
                throw new ArgumentException("Bird can't fly that far");
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
                throw new ArgumentException("Bird can't fly that far");
            }
            double distance = CurrentPosition.CalculateDistance(nextPoint);
            return TimeSpan.FromHours(distance / Speed);

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
