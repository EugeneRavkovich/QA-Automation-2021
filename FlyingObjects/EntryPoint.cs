using System;

namespace InterfacesAndAbstractClasses
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                Bird bird = new Bird(new Coordinate(0, 0, 0), 10);
                Drone drone = new Drone(new Coordinate(0, 0, 0), 36, 36);
                Plane plane = new Plane(new Coordinate(0, 0, 0), 5000, 5000, 1000);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
