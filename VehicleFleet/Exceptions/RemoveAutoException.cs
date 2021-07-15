using System;

namespace VehicleFleet
{
    public class RemoveAutoException: Exception
    {
        public RemoveAutoException() { }

        public RemoveAutoException(string message) : base(message) { }
    }
}
