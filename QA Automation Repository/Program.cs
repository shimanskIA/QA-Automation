using System;
using Task5.Entities;
using Task5.Enums;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Bird raven = new Bird(new Coordinate(0, 1, 0), BirdSpecies.Raven, false, random.NextDouble() * 20);
            raven.GetFlyTime(new Coordinate(100, 150, 80));
            raven.FlyTo(new Coordinate(1, 1, 200));
            Plane plane = new Plane(new Coordinate(12, 25, 633), PlaneManufacturers.Boeing, 13000.5, 900.8, 212.7, 4, 19.35);
            plane.GetFlyTime(new Coordinate(926, 7123, 99));
            plane.FlyTo(new Coordinate(666, 666, 200));
            Drone drone = new Drone(new Coordinate(555, 7, 1), 1000, 8000, 1200, 90);
            drone.GetFlyTime(new Coordinate(926, 111, 94));
            drone.FlyTo(new Coordinate(555, 700, 18));
        }
    }
}
