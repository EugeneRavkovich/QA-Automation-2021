using System;

namespace InterfacesAndAbstractClasses
{
    /// <summary>
    /// Class that defines a bird object
    /// </summary>
    public class Bird: IFlyable
    {
        /// <summary>
        /// Bird's speed, measured in km/h
        /// </summary>
        private float _speed;

        /// <summary>
        /// The maximum distance that bird can cover, measured in km
        /// </summary>
        private double _maxDistance;

        /// <summary>
        /// Current position of a bird
        /// </summary>
        public Coordinate CurrentPosition { get; private set; }

        /// <summary>
        /// Method for setting and getting the _speed field value
        /// </summary>
        public float Speed 
        {
            get 
            {
                return _speed;    
            }
            set 
            {
                if (value < 0) 
                {
                    throw new ArgumentException($"{this.GetType()}: Speed can't be negative");
                }
                _speed = value;
            }
        }

        /// <summary>
        /// Method for setting and getting the _maxDistance field value
        /// </summary>
        public double MaxDistance 
        {
            get 
            {
                return _maxDistance;
            }
            private set 
            {
                if (value < 0) 
                {
                    throw new ArgumentException($"{this.GetType()}: The maximum distance can't be negative");
                }
                _maxDistance = value;
            }
        }
        

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
