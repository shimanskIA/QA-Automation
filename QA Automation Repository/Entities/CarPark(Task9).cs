using System;
using System.Collections.Generic;
using System.Linq;
using Task8.Entities.Vehicles;
using Task8.Exceptions;
using Task8.Helpers;
using Task8.Interfaces;

namespace Task8.Entities
{
    public class CarPark : IReadable
    {
        public List<Vehicle> Vehicles;

        public CarPark(List<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        public CarPark()
        {
            Vehicles = default;
        }

        public void AddVehicleToTheCarPark(Vehicle vehicle)
        {
            try
            {
                Vehicles.Add(vehicle);
            }
            catch
            {
                throw new AddException("Unable to a vehicle to the car park");
            }
        }

        public void Update(int id, Vehicle vehicle)
        {
            try
            {
                int index = Vehicles.FindIndex(0, x => x.Id == id);
                Vehicles[index] = vehicle;
            }
            catch
            {
                throw new UpdateAutoException("Unable to update a vehicle in the car park");
            }
        }

        public void Remove(int id)
        {
            try
            {
                Vehicles.Remove(Vehicles.Find(x => x.Id == id));
            }
            catch
            {
                throw new RemoveAutoException("Unable to remove a vehicle from the car park");
            }
        }

        // method that is more correct than method with exception
        /*public Vehicle GetAutoByParameter(string parameter, string value)
        {
            foreach(var vehicle in Vehicles)
            {  
                var property = vehicle.GetType().GetProperties().Where(x => x.Name == parameter).ToList();  
                if (property.Count() > 0)  
                {    
                    if (property.First().GetValue(vehicle).ToString() == value)     
                    {     
                        return vehicle;   
                    }
                }
            }
            return null;
        }*/

        public Vehicle GetAutoByParameter(string parameter, string value)
        {
            try
            {
                foreach (var vehicle in Vehicles)
                {
                    if (vehicle.GetType().GetProperty(parameter).GetValue(vehicle).ToString() == value)
                    {
                        return vehicle;
                    }
                }
            }
            catch
            {
                throw new GetAutoByParameterException("Unable to get a vehicle from the car park by parameter");
            }
            return null;
        }

        public void SaveToFile(string fileName)
        {
            XmlInteractionHelper.WriteToXmlFile(Vehicles, fileName);
        }

        public void SaveToFileWithCondition(string fileName, Func<Vehicle, bool> function)
        {
            XmlInteractionHelper.WriteToXmlFile(Vehicles.Where(function).ToList(), fileName);
        }

        public void SaveToFileSort<T>(string fileName, Func<Vehicle, T> comparer)
        {
            XmlInteractionHelper.WriteToXmlFile(Vehicles.OrderBy(comparer).ToList(), fileName);
        }

        public void SaveToFileProection<T>(string fileName, Func<Vehicle, bool> function, Func<Vehicle, T> condition)
        {
            XmlInteractionHelper.WriteToXmlFile(Vehicles.Where(function).Select(condition).ToList(), fileName);
        }

        public List<T> ReadFromFile<T>(string fileName)
        {
            return XmlInteractionHelper.ReadFromXmlFile<T>(fileName);
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
