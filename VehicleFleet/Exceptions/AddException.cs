using System;

namespace VehicleFleet
{
    class AddException: Exception
    {
        public AddException() { }
        public AddException(string message) : base(message) { }
    }
}
