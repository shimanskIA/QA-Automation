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

        public void SaveToFile(string fileName)
        {
            Helper.WriteToXmlFile(Vehicles, fileName);
        }

        public void SaveToFileWithCondition(string fileName, Func<Vehicle, bool> function) 
        {
            Helper.WriteToXmlFile(Vehicles.Where(function).ToList(), fileName);
        }

        public void SaveToFileSort<T>(string fileName, Func<Vehicle, T> comparer)
        {
            Helper.WriteToXmlFile(Vehicles.OrderBy(comparer).ToList(), fileName);
        }

        public void SaveToFileProection<T>(string fileName, Func<Vehicle, bool> function, Func<Vehicle, T> condition) 
        {
            Helper.WriteToXmlFile(Vehicles.Where(function).Select(condition).ToList(), fileName);
        }

        public List<T> ReadFromFile<T>(string fileName) 
        {
            return Helper.ReadFromXmlFile<T>(fileName);
        }

        public string GetInformation() // gets information about all vehicles in a list
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
