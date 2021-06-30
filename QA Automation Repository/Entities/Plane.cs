using System;
using Task5.Enums;
using Task5.Interfaces;

namespace Task5.Entities
{
    public class Plane : FlyingObject, IFlyable
    {
        private const int _maximalDistance = 25000; // in kilometers
        private const int _speedInscrease = 10; // in km/h
        private const int _increaseInterval = 10; // in kilometers

        public PlaneManufacturers Manufacturers { get; set; }

        public double MaximalSpeed { get; set; } // in km/h

        public double TakeoffSpeed { get; set; } // in km/h

        public double MaximalHeight { get; set; } // in kilometers

        public int AmountOfEngines { get; set; }

        public double Wingspan { get; set; } // in meters

        public Plane(Coordinate coordinate, PlaneManufacturers manufacturers, double maximalHeight, double maximalSpeed, double takeoffSpeed, int amountOfEngines, double wingspan) : base(coordinate)
        {
            Manufacturers = manufacturers;
            MaximalHeight = maximalHeight;
            MaximalSpeed = maximalSpeed;
            TakeoffSpeed = takeoffSpeed;
            AmountOfEngines = amountOfEngines;
            Wingspan = wingspan;
        }

        public Plane() : base()
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
            if (ActualCoordinate.GetDistance(coordinate) <= _maximalDistance)
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
            if (distance <= _maximalDistance)
            {
                int amountOfSpeedChanges = (int)(distance / _increaseInterval);
                double lastDistance = distance - amountOfSpeedChanges * _increaseInterval;
                double time = 0;
                for (int i = 0; i < amountOfSpeedChanges; i++)
                {
                    time += _increaseInterval / actualSpeed;
                    if (MaximalSpeed - _speedInscrease - actualSpeed < 0)
                    {
                        actualSpeed = MaximalSpeed;
                    }
                    else
                    {
                        actualSpeed += _speedInscrease;
                    }
                }
                return time += (lastDistance / actualSpeed);
            }
            else
            {
                throw new ArgumentOutOfRangeException("planes are not able to fly more than" + _maximalDistance + "km");
            }
        }
    }
}
