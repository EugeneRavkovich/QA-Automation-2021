using System;

namespace VehicleFleet
{
    public class UpdateAutoException: Exception
    {
        public UpdateAutoException() { }

        public UpdateAutoException(string message) : base(message) { }
    }
}
