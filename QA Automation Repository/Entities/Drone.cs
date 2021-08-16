using System;
using Task5.Interfaces;

namespace Task5.Entities
{
    public class Drone : FlyingObject, IFlyable
    {
        private const double _tenMinutesInHours = 1.0 / 6.0;
        private const double _oneMinuteInHours = 1.0 / 60.0;

        public double Price { get; set; } // in us dollars

        public double Speed { get; set; } // in km/h

        public double MaximalHeight { get; set; } // in kilometers

        public double MaximalDistance { get; set; } // in kilometers

        public Drone(Coordinate coordinate, double price, double maximalHeight, double maximalDistance, double speed) : base (coordinate)
        {
            Price = price;
            MaximalHeight = maximalHeight;
            MaximalDistance = maximalDistance;
            Speed = speed;
        }

        public Drone() : base()
        {
            Price = default;
            MaximalHeight = default;
            MaximalDistance = default;
            Speed = default;
        }

        public void FlyTo(Coordinate coordinate) // changes the actual coordinate if distance is less than maximal distance of the flight
        {
            if (ActualCoordinate.GetDistance(coordinate) <= MaximalDistance)
            {
                ActualCoordinate.X = coordinate.X;
                ActualCoordinate.Y = coordinate.Y;
                ActualCoordinate.Z = coordinate.Z;
            }
            else
            {
                throw new ArgumentOutOfRangeException("drones are not able to fly more than " + MaximalDistance + " km");
            }
        }

        public double GetFlyTime(Coordinate coordinate) // each 10 minutes of flight makes a 1 minute pause then moves again
        {
            double distance = ActualCoordinate.GetDistance(coordinate);
            if (distance <= MaximalDistance)
            {
                double baseTime = distance / Speed;
                int amountOfStops = (int)(baseTime / _tenMinutesInHours);
                return baseTime + amountOfStops * _oneMinuteInHours;
            }
            else
            {
                throw new ArgumentOutOfRangeException("drones are not able to fly more than " + MaximalDistance + " km");
            }
        }
    }
}
