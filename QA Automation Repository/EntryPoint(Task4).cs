using System;
using Task4new.Entities.Details;
using Task4new.Entities.Vehicles;
using Task4new.Enums;

namespace Task4new
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Car auto1 = new Car(ManufacturersForTransmissionsAndVehicles.BMW,
                new Engine(250, 2.5, EngineTypes.Petrol, 123),
                new Chassis(4, 4000, 321),
                new Transmission("2x2", 6, ManufacturersForTransmissionsAndVehicles.BMW),
                4);
            Car auto2 = new Car(ManufacturersForTransmissionsAndVehicles.Mitsubishi,
                new Engine(90, 1.1, EngineTypes.Hybrid, 123877),
                new Chassis(4, 4000, 321),
                new Transmission("2x2", 5, ManufacturersForTransmissionsAndVehicles.Mitsubishi),
                4);
            Bus bus1 = new Bus(ManufacturersForTransmissionsAndVehicles.Mercedes,
                new Engine(385, 6.2, EngineTypes.Diesel, 777),
                new Chassis(6, 2000, 751),
                new Transmission("2x4", 7, ManufacturersForTransmissionsAndVehicles.Mercedes),
                48,
                2);
            Lorry lorry1 = new Lorry(ManufacturersForTransmissionsAndVehicles.Citroen,
                new Engine(350, 5.45, EngineTypes.Diesel, 500500),
                new Chassis(4, 1200, 123789),
                new Transmission("2x2", 6, ManufacturersForTransmissionsAndVehicles.Kia),
                5000);
            Scooter scooter1 = new Scooter(ManufacturersForTransmissionsAndVehicles.Ducati,
                new Engine(290, 2.2, EngineTypes.Petrol, 222222),
                new Chassis(2, 250, 123784),
                new Transmission("1x1", 8, ManufacturersForTransmissionsAndVehicles.Ferrari),
                5000);

            Console.Write(auto1.GetInformation());
            Console.Write(auto2.GetInformation());
            Console.Write(bus1.GetInformation());
            Console.Write(lorry1.GetInformation());
            Console.Write(scooter1.GetInformation());
        }
    }
}
