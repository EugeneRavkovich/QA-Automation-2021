using System;

namespace InterfacesAndAbstractClasses
{
    interface IFlyable
    {
        public void FlyTo(Coordinate nextPoint);
        public TimeSpan GetFlyTime(Coordinate nextPoint);
    }
}
