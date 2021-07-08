using System;

namespace VehicleFleet
{
    class InitializationException: Exception
    {
        public InitializationException() { }
        public InitializationException(string message) : base(message) { }
    }
}
