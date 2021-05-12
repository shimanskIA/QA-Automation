using System;
using System.Collections.Generic;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Car, double> calculateEngineVolume = x => x.EngineVolume;
            Func<Car, double> calculatePrice = x => x.Price;
            Predicate<Car> calculateAmountOfElementsByBodyType = x => x.BodyType.Equals("2x2");
            Predicate<Car> calculateAmountOfElementsByEngineType = x => x.EngineType.Equals(EngineTypes.Diesel);
            Predicate<Car> calculateAmountOfElementsByPrice = x => x.Price > 20000;

            CarDealer carDealer = new CarDealer(new List<Car> { new Car(Manufacturers.Mercedes, "ABC", "2x2", EngineTypes.Diesel, 3.2, 16500), new Car(Manufacturers.BMW, "X5", "2x2", EngineTypes.Petrol, 4.5, 35000), new Car(Manufacturers.Audi, "Q5", "2x2", EngineTypes.Diesel, 3.5, 21000), new Car(Manufacturers.MAZ, "Belkomunmash", "2x4", EngineTypes.Hybrid, 5.5, 42000) });
            Console.WriteLine(carDealer.GetAverage(calculateEngineVolume));
            Console.WriteLine(carDealer.GetCount(calculateAmountOfElementsByBodyType));
            Console.WriteLine(carDealer.GetCount(calculateAmountOfElementsByEngineType));
            Console.WriteLine(carDealer.GetCount(calculateAmountOfElementsByPrice));
            Console.WriteLine(carDealer.GetMax(calculateEngineVolume));
            Console.WriteLine(carDealer.GetMax(calculatePrice));
        }
    }


}
