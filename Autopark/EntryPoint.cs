using System;
using System.Collections.Generic;

namespace Homework_4
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Vehicle automobile = new Automobile(3.2, "Type1", 160, 5);
            Vehicle truck = new Truck(4.3, "Type2", 100, 20);
            Vehicle bus = new Bus(5.5, "Type3", 120, "144c");
            Vehicle motorbike = new Motorbike(1.5, "Type4", 220, "Suzuki");
            Autopark park = new Autopark(new List<Vehicle> { automobile, truck, bus, motorbike });
            Console.Write(park.GetFullInfo());
        }
    }
}
