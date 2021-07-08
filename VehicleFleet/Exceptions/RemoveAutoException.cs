using System;

namespace VehicleFleet
{
    class RemoveAutoException: Exception
    {
        public RemoveAutoException() { }
        public RemoveAutoException(string message) : base(message) { }
    }
}
