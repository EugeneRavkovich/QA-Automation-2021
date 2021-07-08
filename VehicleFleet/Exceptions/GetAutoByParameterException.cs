using System;

namespace VehicleFleet
{
    class GetAutoByParameterException: Exception
    {
        public GetAutoByParameterException() { }
        public GetAutoByParameterException(string message) : base(message) { }
    }
}
