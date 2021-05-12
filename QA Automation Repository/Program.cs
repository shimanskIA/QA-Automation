using System;
using System.Collections.Generic;
using System.Linq;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            CarDealer carDealer = new CarDealer(new List<Car> { new Car(Manufacturers.Mercedes, "ABC", "2x2", EngineTypes.Diesel, 3.2, 16500), new Car(Manufacturers.BMW, "X5", "2x2", EngineTypes.Petrol, 4.5, 35000), new Car(Manufacturers.Audi, "Q5", "2x2", EngineTypes.Diesel, 3.5, 21000), new Car(Manufacturers.MAZ, "Belkomunmash", "2x4", EngineTypes.Hybrid, 5.5, 42000) });
            var filter = carDealer.Cars.Where(x => x.BodyType.Equals("2x2") && x.EngineVolume > 3).Select(x => (x.BodyType, x.EngineVolume)).ToList();
            var filter1 = carDealer.Cars.GroupBy(x => x.Manufacturer).Select(x => (x.Key, x.Count())).ToList();
        }
    }


}
