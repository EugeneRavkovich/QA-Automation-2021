using System;

namespace VehicleFleet
{
    class UpdateAutoException: Exception
    {
        public UpdateAutoException() { }
        public UpdateAutoException(string message) : base(message) { }
    }
}
