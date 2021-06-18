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
        public double TakeoffSpeed { get; set; } // in km/h
        public double MaximalHeight { get; set; } // in kilometers
        public int AmountOfEngines { get; set; }
        public double Wingspan { get; set; } // in meters

        public Plane(Coordinate coordinate, PlaneManufacturers manufacturers, double maximalHeight, double maximalSpeed, double takeoffSpeed, int amountOfEngines, double wingspan)
        {
            ActualCoordinate = new Coordinate(coordinate.X, coordinate.Y, coordinate.Z);
            Manufacturers = manufacturers;
            MaximalHeight = maximalHeight;
            MaximalSpeed = maximalSpeed;
            TakeoffSpeed = takeoffSpeed;
            AmountOfEngines = amountOfEngines;
            Wingspan = wingspan;
        }

        public Plane()
        {
            Manufacturers = default;
            MaximalHeight = default;
            AmountOfEngines = default;
            MaximalSpeed = default;
            TakeoffSpeed = default;
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
            double distance = ActualCoordinate.GetDistance(coordinate);
            double actualSpeed = TakeoffSpeed;
            if (distance <= 25000)
            {
                int amountOfSpeedChanges = (int)(distance / 10);
                double lastDistance = distance - amountOfSpeedChanges * 10;
                double time = 0;
                for (int i = 0; i < amountOfSpeedChanges; i++)
                {
                    time += 10 / actualSpeed;
                    if (MaximalSpeed - 10 - actualSpeed < 0)
                    {
                        actualSpeed = MaximalSpeed;
                    }
                    else
                    {
                        actualSpeed += 10;
                    }
                }
                return time += (lastDistance / actualSpeed);
            }
            else
            {
                throw new ArgumentOutOfRangeException("planes are not able to fly more than 25000 km");
            }
        }
    }
}
