using System;
using System.Collections.Generic;

namespace Autopark
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Vehicle passengerCar = new PassengerCar(
                new Engine(230, 3.2, EngineType.Petrol, "E2415O"),
                new Chassis(4, "RT321Q", 2),
                new Transmission(TransmissionType.Automatic, 10, "Jatco"), 4);

            Vehicle truck = new Truck(
                new Engine(350, 5.0, EngineType.Petrol, "T2103I"),
                new Chassis(6, "QI857N", 15),
                new Transmission(TransmissionType.Mechanic, 7, "Jatco"), 12);

            Vehicle bus = new Bus(
                new Engine(160, 5.0, EngineType.Diesel, "I3333U"),
                new Chassis(8, "WQ222Q", 22),
                new Transmission(TransmissionType.Automatic, 7, "Jatko"), "144c");

            Vehicle scooter = new Scooter(
                new Engine(60, 1.2, EngineType.Gas, "KW23121P"),
                new Chassis(4, "123121", 22),
                new Transmission(TransmissionType.Automatic, 4, "Jatko"), 120);

            Autopark park = new Autopark(new List<Vehicle> { passengerCar, truck, bus, scooter});
            Console.Write(park.ToString());

            Serializer<Autopark>.Serialize("../../XMLFiles/CollestionOfAllVehicles.xml", park);
            Serializer<Vehicle>.Serialize("../../XMLFiles/EngineVolumeMoreThan_1.5.xml", park.EngineVolumeMoreThan(1.5));
            Serializer<Engine>.Serialize("../../XMLFiles/EnginesOfBussesAndTrucks.xml", park.EnginesOfBussesAndTrucks());
            Serializer<Vehicle>.Serialize("../../XMLFiles/GroupedByTransmission.xml", park.GroupedByTransmission());
        }
    }
}
