using System;
using Task5.Interfaces;

namespace Task5.Entities
{
    public class Drone : IFlyable
    {
        public Coordinate ActualCoordinate { get; set; } // coordinates are given in kilometers
        public double Price { get; set; } // in us dollars
        public double MaximalHeight { get; set; } // in kilometers
        public double MaximalDistance { get; set; } // in kilometers

        public Drone(Coordinate coordinate, double price, double maximalHeight, double maximalDistance)
        {
            ActualCoordinate = coordinate;
            Price = price;
            MaximalHeight = maximalHeight;
            MaximalDistance = maximalDistance;
        }

        public Drone()
        {
            ActualCoordinate = default;
            Price = default;
            MaximalHeight = default;
            MaximalDistance = default;
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
            if (ActualCoordinate.GetDistance(coordinate) <= MaximalDistance)
            {
                double speed = 50;
                double baseTime = ActualCoordinate.GetDistance(coordinate) / speed;
                int amountOfStops = (int)(baseTime / (1.0 / 6.0));
                return baseTime + amountOfStops * (1.0 / 60.0);
            }
            else
            {
                throw new ArgumentOutOfRangeException("drones are not able to fly more than " + MaximalDistance + " km");
            }
        }
    }
}
