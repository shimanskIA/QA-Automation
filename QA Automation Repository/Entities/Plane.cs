using System;
using Task5.Helpers;
using Task5.Interfaces;

namespace Task5.Entities
{
    public class Plane : IFlyable
    {
        public Coordinate ActualCoordinate { get; set; }
        public PlaneManufacturers Manufacturers { get; set; }
        public double MaximalSpeed { get; set; }
        public double MaximalHeight { get; set; }
        public int AmountOfEngines { get; set; }
        public double Wingspan { get; set; }

        public Plane(Coordinate actualCoordinate, PlaneManufacturers manufacturers, double maximalHeight, double maximalSpeed, int amountOfEngines, double wingspan)
        {
            ActualCoordinate = actualCoordinate;
            Manufacturers = manufacturers;
            MaximalHeight = maximalHeight;
            MaximalSpeed = maximalSpeed;
            AmountOfEngines = amountOfEngines;
            Wingspan = wingspan;
        }

        public Plane()
        {
            Manufacturers = default;
            MaximalHeight = default;
            AmountOfEngines = default;
            MaximalSpeed = default;
            Wingspan = default;
        }

        public void FlyTo(Coordinate coordinate)
        {
            if (ActualCoordinate.GetDistance(coordinate) <= 25000)
            {
                ActualCoordinate.X = coordinate.X;
                ActualCoordinate.Y = coordinate.Y;
                ActualCoordinate.Z = coordinate.Z;
            }
            else
            {
                throw new ArgumentOutOfRangeException("planes are not able to fly more than 25000 km");
            }
        }

        public double GetFlyTime(Coordinate coordinate)
        {
            double speed = 200;
            double distance = ActualCoordinate.GetDistance(coordinate);
            int amountOfSpeedChanges = (int)(distance / 10);
            double lastDistance = distance - amountOfSpeedChanges * 10;
            double time = 0;
            for (int i = 0; i < amountOfSpeedChanges; i++)
            {
                time += 10 / speed;
                if (speed > MaximalSpeed || Math.Abs(speed - MaximalSpeed) < 1e-10)
                {
                    speed = MaximalSpeed;
                }
                else
                {
                    speed += 10;
                }
            }
            return time += (lastDistance / speed);
        }
    }
}
