using System;

namespace InterfacesAndAbstractClasses
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                IFlyable[] flyingObjects =
                {
                    new Bird(new Coordinate(0, 0, 0), 20),
                    new Drone(new Coordinate(0, 0, 0), 36, 36),
                    new Plane(new Coordinate(0, 0, 0), 5000, 5000, 1000)
                };

                foreach (var obj in flyingObjects) 
                {
                    Console.WriteLine(obj.GetFlyTime(new Coordinate(10, 10, 10)));
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
