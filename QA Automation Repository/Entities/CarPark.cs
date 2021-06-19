using System;
using System.Collections.Generic;
using System.Linq;
using Task4.Entities.Vehicles;
using Task4.Helpers;
using Task4.Interfaces;

namespace Task4.Entities
{
    public class CarPark : IReadable
    {
        public List<Vehicle> Vehicles { get; set; }

        public CarPark(List<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        public CarPark()
        {
            Vehicles = default;
        }

        public void SaveToFile(string fileName) // saves all vehicles to file
        {
            Helper.XmlWriter(Vehicles, fileName);
        }

        public void SaveToFileWithCondition(string fileName, Func<Vehicle, bool> function) // saves some vehicles to file depends on condition
        {
            Helper.XmlWriter(Vehicles.Where(function).ToList(), fileName);
        }

        public void SaveToFileSort<T>(string fileName, Func<Vehicle, T> comparer) // saves sorted list of vehicles to file
        {
            Helper.XmlWriter(Vehicles.OrderBy(comparer).ToList(), fileName);
        }

        public void SaveToFileProection<T>(string fileName, Func<Vehicle, bool> function, Func<Vehicle, T> condition) // saves some complex proection of list of vehicles to file
        {
            Helper.XmlWriter(Vehicles.Where(function).Select(condition).ToList(), fileName);
        }

        public List<T> ReadFromFile<T>(string fileName) // reads objects from file
        {
            return Helper.XmlReader<T>(fileName);
        }

        public string GetInformation() // gets information about all vehicles in list
        {
            string fullInformation = "";
            foreach (var vehicle in Vehicles)
            {
                fullInformation += vehicle.GetInformation();
                fullInformation += "\n";
            }
            return fullInformation;
        }
    }
}
