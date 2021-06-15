using System;
using Task4.Entities.Details;
using Task4.Entities.Vehicles;
using Task4.Helpers;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Car auto1 = new Car(Manufacturers.BMW, new Engine(250, 2.5, EngineTypes.Petrol, 123), new Chassis(4, 4000, 321), new Transmission("2x2", 6, Manufacturers.BMW), 4);
            Console.WriteLine(auto1.GetInformation());
            Bus bus1 = new Bus(Manufacturers.Mercedes, new Engine(385, 6.2, EngineTypes.Diesel, 777), new Chassis(6, 2000, 751), new Transmission("2x4", 7, Manufacturers.Mercedes), 48, 2);
            Console.WriteLine(bus1.GetInformation());
        }
    }
}
