using System;

namespace VehicleFleet
{
    public class GetAutoByParameterException: Exception
    {
        public GetAutoByParameterException() { }
        public GetAutoByParameterException(string message) : base(message) { }
    }
}
