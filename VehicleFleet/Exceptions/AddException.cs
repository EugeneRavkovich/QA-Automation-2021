﻿using System;

namespace VehicleFleet
{
    public class AddException: Exception
    {
        public AddException() { }
        public AddException(string message) : base(message) { }
    }
}
