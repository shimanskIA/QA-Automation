using System;
using Task5.Helpers;
using Task5.Interfaces;

namespace Task5.Entities
{
    public class Plane : IFlyable
    {
        public Coordinate ActualCoordinate { get; set; } // coordinates are given in kilometers
        public PlaneManufacturers Manufacturers { get; set; }
        public double MaximalSpeed { get; set; } // in km/h
        public double MaximalHeight { get; set; } // in kilometers
        public int AmountOfEngines { get; set; }
        public double Wingspan { get; set; } // in meters

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

        public void FlyTo(Coordinate coordinate) // changes the actual coordinate if distance is less than 25000 km
        {
            if (ActualCoordinate.GetDistance(coordinate) <= 25000)
            {
                ActualCoordinate.X = coordinate.X;
                ActualCoordinate.Y = coordinate.Y;
                ActualCoordinate.Z = coordinate.Z;
            }
            else
            {
                // some airport coordinates
                ActualCoordinate.X = 100;
                ActualCoordinate.Y = 100;
                ActualCoordinate.Z = 100;
            }
        }

        public double GetFlyTime(Coordinate coordinate) // every 10 kilometers the speed increases in 10 km/h
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
