using System;

namespace VehicleFleet
{
    public class InitializationException: Exception
    {
        public InitializationException() { }

        public InitializationException(string message) : base(message) { }
    }
}
