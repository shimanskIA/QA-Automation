using System;
using System.Collections.Generic;
using Task8.Entities;
using Task8.Entities.Details;
using Task8.Entities.Vehicles;
using Task8.Enums;
using Task8.Helpers;

namespace Task8
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Func<Vehicle, bool> chooseMoreThan15 = x => x.VehicleEngine.Volume >= 1.5;
            Func<Vehicle, bool> choose2x2Transmission = x => x.VehicleTransmission.TransmissionType == "2x2";
            Func<Vehicle, string> transmissionComparer = x => x.VehicleTransmission.TransmissionType;
            Func<Vehicle, bool> chooseVehicleType = x => x.GetType().Equals(typeof(Lorry)) || x.GetType().Equals(typeof(Bus));
            Func<Vehicle, SerialClass> proectionCondition = x => new SerialClass(x.VehicleEngine.EngineType, x.VehicleEngine.SerialNumber, x.VehicleEngine.Power);

            string fileForVehiclesName = "Vehicles.xml";
            string fileForVehiclesWithEngineVolume15Name = "Vehicles15.xml";
            string fileLorryAndBusEngines = "LorryAndBusEngines.xml";
            string fileVehiclesWith2x2Transmission = "2x2VehicleTypes.xml";
            string fileForSortedByTransmissionVehicles = "SortedTransmissions.xml";

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

            List<Vehicle> vehicles = new List<Vehicle>() { auto1, bus1, lorry1, scooter1, auto2 };
            CarPark carPark = new CarPark(vehicles);
            Console.Write(carPark.GetInformation());
            carPark.SaveToFile(fileForVehiclesName);
            carPark.SaveToFileWithCondition(fileForVehiclesWithEngineVolume15Name, chooseMoreThan15);
            carPark.SaveToFileProection(fileLorryAndBusEngines, chooseVehicleType, proectionCondition);
            carPark.SaveToFileWithCondition(fileVehiclesWith2x2Transmission, choose2x2Transmission);
            carPark.SaveToFileSort(fileForSortedByTransmissionVehicles, transmissionComparer);
            List<Vehicle> vehiclesWithEngineVolume15FromFile = carPark.ReadFromFile<Vehicle>(fileForVehiclesWithEngineVolume15Name);
            List<SerialClass> enginesFromFile = carPark.ReadFromFile<SerialClass>(fileLorryAndBusEngines);
            List<Vehicle> vehiclesChosenByTransmissionFromFile = carPark.ReadFromFile<Vehicle>(fileVehiclesWith2x2Transmission);
            List<Vehicle> sortedVehiclesByTransmission = carPark.ReadFromFile<Vehicle>(fileForSortedByTransmissionVehicles);

            Bus bus2 = new Bus(ManufacturersForTransmissionsAndVehicles.Volvo,
                new Engine(290, 4.7, EngineTypes.Petrol, 288),
                new Chassis(4, 1600, 911),
                new Transmission("2x2", 5, ManufacturersForTransmissionsAndVehicles.Volkswagen),
                35,
                2);
            Scooter scooter2 = new Scooter(ManufacturersForTransmissionsAndVehicles.Suzuki,
                new Engine(155, 1, EngineTypes.Petrol, 1515157),
                new Chassis(2, 180, 123536),
                new Transmission("1x1", 4, ManufacturersForTransmissionsAndVehicles.Nissan),
                6700);
            Lorry lorry2 = new Lorry(ManufacturersForTransmissionsAndVehicles.Nissan,
                new Engine(310, 4.1, EngineTypes.Diesel, 500501),
                new Chassis(4, 990, 123790),
                new Transmission("2x2", 6, ManufacturersForTransmissionsAndVehicles.Nissan),
                -5);

            carPark.AddVehicleToTheCarPark(bus2);
            carPark.Remove(3);
            carPark.Update(2, scooter2);
            carPark.GetAutoByParameter("Manufacturer", "Suzuki");
        }
    }
}
