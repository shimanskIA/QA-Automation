using System;
using System.Collections.Generic;
using System.Linq;
using Task4.Entities;
using Task4.Entities.Details;
using Task4.Entities.Vehicles;
using Task4.Helpers;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Car auto1 = new Car(Manufacturers.BMW, 
                new Engine(250, 2.5, EngineTypes.Petrol, 123), 
                new Chassis(4, 4000, 321), 
                new Transmission("2x2", 6, Manufacturers.BMW), 
                4);
            Car auto2 = new Car(Manufacturers.Mitsubishi,
                new Engine(90, 1.1, EngineTypes.Hybrid, 123877),
                new Chassis(4, 4000, 321),
                new Transmission("2x2", 5, Manufacturers.Mitsubishi),
                4);
            Console.WriteLine(auto1.GetInformation());
            Bus bus1 = new Bus(Manufacturers.Mercedes, 
                new Engine(385, 6.2, EngineTypes.Diesel, 777), 
                new Chassis(6, 2000, 751), 
                new Transmission("2x4", 7, Manufacturers.Mercedes), 
                48, 
                2);
            Console.WriteLine(bus1.GetInformation());
            Lorry lorry1 = new Lorry(Manufacturers.Citroen, 
                new Engine(350, 5.45, EngineTypes.Diesel, 500500), 
                new Chassis(4, 1200, 123789), 
                new Transmission("2x2", 6, Manufacturers.Kia), 
                5000);
            Console.WriteLine(lorry1.GetInformation());
            Scooter scooter1 = new Scooter(Manufacturers.Ducati,
                new Engine(290, 2.2, EngineTypes.Petrol, 222222),
                new Chassis(2, 250, 123784),
                new Transmission("1x1", 8, Manufacturers.Ferrari),
                5000);
            Console.WriteLine(scooter1.GetInformation());
            List<Vehicle> vehicles = new List<Vehicle>() { auto1, bus1, lorry1, scooter1, auto2 };
            Helper.XmlWriter(vehicles, "Vehicles.xml");
            List<Vehicle> vehiclesFromFile = new List<Vehicle>();
            vehiclesFromFile = Helper.XmlReader<Vehicle>("Vehicles.xml");
            Helper.XmlWriter(vehicles.Where(x => x.VehicleEngine.Volume >= 1.5).ToList(), "Vehicles15.xml");
            Helper.XmlWriter<SerialClass>(vehicles.Where(x => x.GetType().Equals(typeof(Lorry)) || x.GetType().Equals(typeof(Bus))).Select(x => new SerialClass(x.VehicleEngine.EngineType, x.VehicleEngine.SerialNumber, x.VehicleEngine.Power)).ToList(), "LorryAndBusEngines.xml");
            Helper.XmlWriter(vehicles.Where(x => x.VehicleTransmission.TransmissionType == "2x2").ToList(), "2x2VehicleTypes.xml");
        }
    }
}
