using System;

namespace InterfacesAndAbstractClasses
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                Bird bird = new Bird(new Coordinate(0, 0, 0),4);
                var q = bird.GetFlyTime(new Coordinate(3, 4, 0));
                bird.FlyTo(new Coordinate(1, 1, 0));
                var w = bird.GetFlyTime(new Coordinate(3, 4, 0));
                Console.WriteLine(q);
                Console.WriteLine(w);
                Console.WriteLine(bird.Speed);

                Plane plane = new Plane(new Coordinate(0, 0, 0), 50000, 4000, 1000);
                var a = plane.GetFlyTime(new Coordinate(30, 40, 0));
                plane.FlyTo(new Coordinate(100, 100, 0));
                var s = plane.GetFlyTime(new Coordinate(3000, 4000, 0));
                Console.WriteLine(a);
                Console.WriteLine(s);

                Drone drone = new Drone(new Coordinate(0, 0, 0), 1000, 36);
                var g = drone.GetFlyTime(new Coordinate(9 * Math.Sqrt(2), 9 * Math.Sqrt(2), 0));
                Console.WriteLine(g);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
